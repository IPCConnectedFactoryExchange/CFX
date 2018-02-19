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

namespace CFX.Transport
{
    public class AmqpRequestProcessor
    {
        public AmqpRequestProcessor()
        {
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

        public event OnRequestHandler OnRequestReceived;

        private ContainerHost inboundHost;
        
        public void Open(string cfxHandle, Uri requestUri = null)
        {
            if (string.IsNullOrEmpty(cfxHandle)) throw new ArgumentException("You must supply a CFX Handle");

            this.CFXHandle = cfxHandle;

            if (requestUri != null)
                RequestUri = requestUri;
            else
                RequestUri = new Uri(string.Format("amqp://{0}:5672", EnvironmentHelper.GetMachineName()));

            Task.Run(() =>
            {
                if (!string.IsNullOrWhiteSpace(RequestUri.UserInfo))
                    inboundHost = new ContainerHost(new Uri[] { RequestUri }, null, RequestUri.UserInfo);
                else
                    inboundHost = new ContainerHost(RequestUri);

                inboundHost.Open();
                Debug.WriteLine("Container host is listening on {0}:{1}.  User {2}", RequestUri.Host, RequestUri.Port, requestUri.UserInfo);

                inboundHost.RegisterRequestProcessor(RequestHandle, new InternalRequestProcessor(this));
                Debug.WriteLine("Request processor is registered on {0}", RequestHandle);
            }).Wait();
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
                temp.Close();
            }

            this.inboundHost = null;
        }

        protected CFXEnvelope Fire_OnRequestReceived(CFXEnvelope request)
        {
            if (OnRequestReceived != null) return OnRequestReceived(request);
            return null;
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
                var task = Task.Run(() =>
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
                });

                Task.WaitAll(new Task[] { task });
            }
        }

        class InternalMessageProcessor : IMessageProcessor
        {
            public InternalMessageProcessor(AmqpRequestProcessor p)
            {
                processor = p;
            }

            AmqpRequestProcessor processor;

            int IMessageProcessor.Credit
            {
                get { return 100; }
            }

            void IMessageProcessor.Process(MessageContext messageContext)
            {
                messageContext.Complete();
            }
        }
    }

    public delegate CFXEnvelope OnRequestHandler(CFXEnvelope request);
}
