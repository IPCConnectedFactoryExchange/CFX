using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Amqp;
using Amqp.Listener;
using Amqp.Framing;
using CFX.Utilities;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Concurrent;

namespace CFX.Transport
{
    internal class AmqpRequestProcessor
    {
        public AmqpRequestProcessor()
        {
            IsOpen = false;
            listeners = new ConcurrentDictionary<string, InternalMessageProcessor>();
        }
                
        public Uri RequestUri
        {
            private set;
            get;
        }

        public TimeSpan SendTimout
        {
            get;
            set;
        }

        public string CFXHandle
        {
            private set;
            get;
        }

        public string RequestHandle
        {
            get
            {
                return CFXHandle;
            }
        }

        public bool IsOpen
        {
            get;
            private set;
        }
        

        public event OnRequestHandler OnRequestReceived;
        public event CFXMessageReceivedFromListenerHandler OnMessageReceivedFromListener;

        private ConcurrentDictionary<string, InternalMessageProcessor> listeners;
        private ContainerHost inboundHost;

        public void Open(string cfxHandle, Uri requestUri, X509Certificate2 certificate = null)
        {
            IsOpen = false;
            if (string.IsNullOrEmpty(cfxHandle)) throw new ArgumentException("You must supply a CFX Handle");

            this.CFXHandle = cfxHandle;
            RequestUri = requestUri;

            inboundHost = new ContainerHost(RequestUri);
            
            Task.Run(() =>
            {
                if (!string.IsNullOrWhiteSpace(RequestUri.UserInfo))
                    inboundHost = new ContainerHost(new Uri[] { RequestUri }, null, RequestUri.UserInfo);
                else
                    inboundHost = new ContainerHost(RequestUri);

                var listener = inboundHost.Listeners[0];

                if (certificate != null)
                {
                    listener.SSL.Certificate = certificate;
                    listener.SSL.ClientCertificateRequired = true;
                    listener.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
                    listener.SASL.EnableExternalMechanism = true;
                }

                if (string.IsNullOrWhiteSpace(RequestUri.UserInfo))
                {
                    listener.SASL.EnableExternalMechanism = false;
                    listener.SASL.EnableAnonymousMechanism = true;
                }

                inboundHost.Open();
                AppLog.Info($"Container host is listening on {RequestUri.Host}:{RequestUri.Port}.  User {requestUri.UserInfo}");

                inboundHost.RegisterRequestProcessor(RequestHandle, new InternalRequestProcessor(this));
                AppLog.Info($"Request processor is registered on {RequestHandle}");
                IsOpen = true;
            }).Wait();
        }

        public void AddListener(string targetAddress)
        {
            if (!IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to receive messages on a listener.");

            string t = targetAddress.ToUpper();
            if (listeners.ContainsKey(t)) throw new Exception("The specified targetAddress is already in use.");

            Exception ex = null;
            Task.Run(() =>
            {
                try
                {
                    InternalMessageProcessor p = new InternalMessageProcessor(this, targetAddress);
                    inboundHost.RegisterMessageProcessor(targetAddress, p);
                    AppLog.Info($"Listener registered on {targetAddress}");
                    listeners[t] = p;
                }
                catch (Exception exception)
                {
                    ex = exception;
                    AppLog.Error(ex);
                }
            }).Wait();

            if (ex != null) throw ex;
        }

        public void RemoveListener(string targetAddress)
        {
            string t = targetAddress.ToUpper();
            if (!listeners.ContainsKey(t)) throw new Exception("The specified targetAddress does not have an active listener.");
            inboundHost.UnregisterMessageProcessor(targetAddress);
            while (!listeners.TryRemove(targetAddress, out InternalMessageProcessor p)) Task.Yield();
        }

        public void Close()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            var temp = Interlocked.Exchange(ref inboundHost, null);
            if (temp != null)
            {
                foreach (InternalMessageProcessor p in listeners.Values)
                {
                    temp.UnregisterMessageProcessor(p.TargetAddress);
                }
                listeners.Clear();

                temp.UnregisterRequestProcessor(RequestHandle);
                temp.Close();
            }

            this.inboundHost = null;
        }

        static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (certificate != null)
            {
                Console.WriteLine("Received remote certificate. Subject: {0}, Policy errors: {1}", certificate.Subject, sslPolicyErrors);
            }

            return true;
        }

        protected CFXEnvelope Fire_OnRequestReceived(CFXEnvelope request)
        {
            if (OnRequestReceived != null) return OnRequestReceived(request);
            return null;
        }

        protected void Fire_OnMessageReceivedFromListener(string TargetAddress, CFXEnvelope message)
        {
            if (OnMessageReceivedFromListener != null) OnMessageReceivedFromListener(TargetAddress, message);
        }

        class InternalRequestProcessor : IRequestProcessor
        {
            public InternalRequestProcessor(AmqpRequestProcessor p)
            {
                processor = p;
            }

            AmqpRequestProcessor processor;

            int IRequestProcessor.Credit
            {
                get { return 100; }
            }

            void IRequestProcessor.Process(RequestContext requestContext)
            {
                Task.Run(() =>
                {
                    CFXEnvelope request = AmqpUtilities.EnvelopeFromMessage(requestContext.Message);
                    CFXEnvelope response = processor.Fire_OnRequestReceived(request);
                    if (response != null)
                    {
                        response.Source = processor.CFXHandle;
                        response.Target = request.Source;
                        response.RequestID = request.RequestID;
                        requestContext.Complete(AmqpUtilities.MessageFromEnvelope(response));
                    }
                    else
                    {
                        requestContext.Complete(AmqpUtilities.MessageFromEnvelope(new CFXEnvelope(new CFX.NotSupportedResponse())
                        {
                            Source = processor.CFXHandle,
                            Target = request.Source,
                            RequestID = request.RequestID
                        }));
                    }
                }).Wait();
            }
        }

        class InternalMessageProcessor : IMessageProcessor
        {
            public InternalMessageProcessor(AmqpRequestProcessor p, string targetAddress)
            {
                parentProcessor = p;
                TargetAddress = targetAddress;
            }

            private AmqpRequestProcessor parentProcessor;
            public string TargetAddress
            {
                get;
                private set;
            }

            int IMessageProcessor.Credit
            {
                get { return 100; }
            }

            void IMessageProcessor.Process(MessageContext messageContext)
            {
                try
                {
                    List<CFXEnvelope> messages = AmqpUtilities.EnvelopesFromMessage(messageContext.Message);
                    if (messages != null && messages.Any())
                    {
                        foreach (CFXEnvelope message in messages)
                        {
                            parentProcessor.Fire_OnMessageReceivedFromListener(TargetAddress, message);
                        }
                    }
                    else
                    {
                        AppLog.Warn($"Undecodeable message received on listener {TargetAddress}");
                    }
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                }

                messageContext.Complete();
            }
        }

        class InternalLinkProcessor : ILinkProcessor
        {
            public InternalLinkProcessor(AmqpRequestProcessor requestProcessor, string targetAddress)
            {
                parentProcessor = requestProcessor;
                TargetAddress = targetAddress;
            }

            private AmqpRequestProcessor parentProcessor;
            private string TargetAddress
            {
                get;
                set;
            }

            public void Process(AttachContext attachContext)
            {
                // start a task to process this request
                var task = this.ProcessAsync(attachContext);
            }

            async Task ProcessAsync(AttachContext attachContext)
            {
                if (attachContext.Attach.LinkName == "")
                {
                    // how to fail the attach request
                    attachContext.Complete(new Error(ErrorCode.InvalidField) { Description = "Empty link name not allowed." });
                }
                else if (attachContext.Link.Role)
                {
                    var target = attachContext.Attach.Target as Target;
                    if (target != null)
                    {
                        if (string.Compare(target.Address, TargetAddress, true) == 0)
                        {
                            // how to do manual link flow control
                            attachContext.Complete(new InternalIncomingLinkEndpoint(parentProcessor, TargetAddress), 300);
                        }
                        else
                        {
                            attachContext.Complete(new Error(ErrorCode.InvalidField) { Description = "Target address not found." });
                        }
                    }
                }
            }
        }

        class InternalIncomingLinkEndpoint : LinkEndpoint
        {
            public InternalIncomingLinkEndpoint(AmqpRequestProcessor requestProcessor, string targetAddress)
            {
                parentProcessor = requestProcessor;
            }

            private AmqpRequestProcessor parentProcessor;
            private string targetAddress;

            public override void OnMessage(MessageContext messageContext)
            {
                try
                {
                    CFXEnvelope message = AmqpUtilities.EnvelopeFromMessage(messageContext.Message);
                    if (message != null)
                    {
                        parentProcessor.Fire_OnMessageReceivedFromListener(targetAddress, message);
                    }
                    else
                    {
                        AppLog.Warn($"Undecodeable message received on listener {targetAddress}");
                    }
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                }

                messageContext.Complete();
            }

            public override void OnFlow(FlowContext flowContext)
            {
            }

            public override void OnDisposition(DispositionContext dispositionContext)
            {
            }
        }

    }

    public delegate CFXEnvelope OnRequestHandler(CFXEnvelope request);
}
