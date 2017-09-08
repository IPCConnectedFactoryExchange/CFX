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

namespace CFX.Transport
{
    public class AmqpRequestProcessor
    {
        public AmqpRequestProcessor()
        {
            InboundPort = 5672;
            InboundHostName = "127.0.0.1";
        }
                
        public string InboundAddress
        {
            get
            {
                return string.Format("amqp://guest:guest@{0}:{1}", "127.0.0.1" /*Environment.MachineName*/, InboundPort);
            }
        }

        public string InboundHostName
        {
            get;
            set;
        }

        public int InboundPort
        {
            get;
            set;
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
                return CFXHandle + "-REQUEST";
            }
        }

        public delegate CFXEnvelope OnRequestHandler(CFXEnvelope request);
        public delegate bool OnMessageHandler(CFXEnvelope message);

        public event OnRequestHandler OnRequestReceived;
        public event OnMessageHandler OnMessageReceived;

        private ContainerHost inboundHost;
        
        public void Open(string CFXHandle)
        {
            var task = Task.Run(() =>
            {
                this.CFXHandle = CFXHandle;

                Uri addressUri = new Uri(InboundAddress);
                inboundHost = new ContainerHost(new Uri[] { addressUri }, null, addressUri.UserInfo);
                inboundHost.Open();
                Debug.WriteLine("Container host is listening on {0}:{1}", addressUri.Host, addressUri.Port);

                inboundHost.RegisterRequestProcessor(RequestHandle, new InternalRequestProcessor(this));
                Debug.WriteLine("Request processor is registered on {0}", RequestHandle);

                inboundHost.RegisterMessageProcessor(CFXHandle, new InternalMessageProcessor(this));
                Debug.WriteLine("Message processor is registered on {0}", CFXHandle);
            });

            Task.WaitAll(new Task[] { task });
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

        protected bool Fire_OnMessageReceived(CFXEnvelope message)
        {
            if (OnMessageReceived != null) return OnMessageReceived(message);
            return false;
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
                        requestContext.Complete(AmqpUtilities.MessageFromEnvelope(response));
                        //requestContext.ResponseLink.SendMessage(response);
                    }
                    else
                    {
                        requestContext.Complete(new Message("NO REQUEST"));
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
                var task = Task.Run(() =>
                {
                    CFXEnvelope message = AmqpUtilities.EnvelopeFromMessage(messageContext.Message);
                    if (processor.Fire_OnMessageReceived(message))
                    {
                        messageContext.Complete();
                    }
                    else
                    {
                        messageContext.Complete(new Error() { Condition = ErrorCode.NotImplemented, Description = "Message was not processed.." });
                    }
                });

                Task.WaitAll(new Task[] { task });
            }
        }
    }
}
