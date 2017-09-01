using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Amqp;
using Amqp.Framing;
using Amqp.Listener;
using System.Text;
using CFX.Utilities;
using Amqp.Types;

namespace CFX.Connection
{
    public class AmqpChannel : IDisposable
    {
        private string inboundAddress;
        private string inboundName;
        private ContainerHost inboundHost;
        private Session inboundSession;
        private ReceiverLink inboundReceiver;
        private SenderLink inboundSender;
        private Amqp.Connection outboundConnection;
        private Session outboundSession;
        private ReceiverLink outboundReceiver;
        private SenderLink outboundSender;
        private int offset;
        private int linkCredit;

        public AmqpChannel()
        {
            linkCredit = 300;
            InboundPort = 5672;
            SendTimout = TimeSpan.FromSeconds(5);
        }

        private Task task;
        private CancellationTokenSource tokenSource;

        public string InboundAddress
        {
            get
            {
                return string.Format("amqp://guest:guest@{0}:{1}", "127.0.0.1" /*Environment.MachineName*/, InboundPort);
            }
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

        public void Listen(string CFXHandle)
        {
            var task = Task.Run(() =>
            {
                Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

                Uri addressUri = new Uri(InboundAddress);
                inboundHost = new ContainerHost(new Uri[] { addressUri }, null, addressUri.UserInfo);
                inboundHost.Open();
                Debug.WriteLine("Container host is listening on {0}:{1}", addressUri.Host, addressUri.Port);

                //inboundHost.RegisterLinkProcessor(new LinkProcessor());

                string requestProcessor = "request_processor";
                inboundHost.RegisterRequestProcessor(requestProcessor, new RequestProcessor());
                Debug.WriteLine("Request processor is registered on {0}", requestProcessor);
            });

            Task.WaitAll(new Task[] { task });
        }

        public void Connect(string address, string CFXHandle)
        {
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            var task = Task.Run(() => ConnectAsync(address, CFXHandle));
            Task.WaitAll(new Task[] { task });
        }

        private void ConnectAsync(string address, string CFXHandle)
        {
            //Open open = new Open();
            //outboundConnection = new Amqp.Connection(new Address(address), Amqp.Sasl.SaslProfile.Anonymous, open, null);
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            outboundConnection = new Amqp.Connection(new Address(address));
            outboundSession = new Session(outboundConnection);

            outboundReceiver = new ReceiverLink(outboundSession, CFXHandle, "request_receiver");
            outboundReceiver.Start(linkCredit, OnMessageReceived);
            outboundSender = new SenderLink(outboundSession, CFXHandle + "-sender", "request_processor");
        }

        public void Send(object message, string replyTo)
        {
            if (outboundConnection == null)
            {
                throw new Exception("Connection not open");
            }

            var task = Task.Run(() =>
            {
                byte[] data = null;
                if (message is string)
                {
                    data = Encoding.UTF8.GetBytes(message as string);
                }
                else
                {
                    data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                }

                Message msg = new Message(data);
                msg.Properties = new Properties() { MessageId = "command-request", ReplyTo = replyTo };
                msg.ApplicationProperties = new ApplicationProperties();
                msg.ApplicationProperties["offset"] = this.offset;

                //outboundSender.Send(msg, SendTimout);
                outboundSender.Send(msg, OnRequestResponse, null);
            });

            Task.WaitAll(new Task[] { task });
        }

        private void OnRequestResponse(Amqp.ILink sender, Amqp.Message message, Amqp.Framing.Outcome outcome, object state)
        {

        }

        public void Close()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void OnMessageReceived(IReceiverLink receiver, Message message)
        {
            Debug.WriteLine(Encoding.UTF8.GetString(message.GetBody<byte []>()));

        }

        private void Cleanup()
        {
            var temp = Interlocked.Exchange(ref this.inboundHost, null);
            if (temp != null)
            {
                temp.Close();
            }

            var temp2 = Interlocked.Exchange(ref this.outboundConnection, null);
            if (temp2 != null)
            {
                temp2.Close();
            }

            this.inboundHost = null;
            this.outboundConnection = null;
        }

        class LinkProcessor : ILinkProcessor
        {
            public void Process(AttachContext attachContext)
            {
                attachContext.Complete(new MonitoringLinkEndpoint(attachContext.Link), 0);

                //if (!attachContext.Attach.Role)
                //{
                //    attachContext.Complete(new Error() { Condition = ErrorCode.NotAllowed, Description = "Only receiver link is allowed." });
                //    return;
                //}

                //string address = ((Source)attachContext.Attach.Source).Address;
                //if (!string.Equals("$monitoring", address, StringComparison.OrdinalIgnoreCase))
                //{
                //    attachContext.Complete(new Error() { Condition = ErrorCode.NotFound, Description = "Cannot find address " + address });
                //    return;
                //}

                //Console.WriteLine("A client has connected. LinkName " + attachContext.Attach.LinkName);
                //attachContext.Complete(new Error() { Condition = ErrorCode.NotFound, Description = "Cannot find address " + address });
                //attachContext.Complete(new MonitoringLinkEndpoint(attachContext.Link), 0);
            }
        }

        class MonitoringLinkEndpoint : LinkEndpoint
        {
            ListenerLink link;
            Random random;
            Timer timer;
            int credit;

            public MonitoringLinkEndpoint(ListenerLink link)
            {
                this.link = link;
                this.link.Closed += Link_Closed;
                this.random = new Random();
                this.timer = new Timer(OnTimer, this, 1000, 1000);
            }

            private void Link_Closed(IAmqpObject sender, Error error)
            {
                Debug.WriteLine("A client has disconnected.");
                this.timer.Dispose();
            }

            public override void OnFlow(FlowContext flowContext)
            {
                Interlocked.Add(ref this.credit, flowContext.Messages);
            }

            public override void OnDisposition(DispositionContext dispositionContext)
            {
            }

            static void OnTimer(object state)
            {
                
                //var thisPtr = (MonitoringLinkEndpoint)state;
                //if (Interlocked.Decrement(ref thisPtr.credit) >= 0)
                //{
                //    var message = new Message(new Map()
                //        {
                //            { "CPU", thisPtr.random.Next(10, 100) },
                //            { "Memory", thisPtr.random.Next(2, 2048) }
                //        });
                //    message.Properties = new Properties();
                //    message.Properties.MessageId = "Machine Status";

                //    try
                //    {
                //        thisPtr.link.SendMessage(message);
                //    }
                //    catch (Exception exception)
                //    {
                //        Console.WriteLine("Exception: " + exception.Message);
                //    }
                //}
                //else
                //{
                //    Interlocked.Increment(ref thisPtr.credit);
                //}
            }
        }

        class RequestProcessor : IRequestProcessor
        {
            int offset;

            int IRequestProcessor.Credit
            {
                get { return 100; }
            }

            void IRequestProcessor.Process(RequestContext requestContext)
            {
                Debug.WriteLine("Received a request " + Encoding.UTF8.GetString((byte[])requestContext.Message.Body));
                //var task = this.ReplyAsync(requestContext);
            }

            async Task ReplyAsync(RequestContext requestContext)
            {
                if (this.offset == 0)
                {
                    this.offset = (int)requestContext.Message.ApplicationProperties["offset"];
                }

                while (this.offset < 1000)
                {
                    try
                    {
                        Message response = new Message("reply" + this.offset);
                        response.ApplicationProperties = new ApplicationProperties();
                        response.ApplicationProperties["offset"] = this.offset;
                        requestContext.ResponseLink.SendMessage(response);
                        this.offset++;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine("Exception: " + exception.Message);
                        if (requestContext.State == ContextState.Aborted)
                        {
                            Debug.WriteLine("Request is aborted. Last offset: " + this.offset);
                            return;
                        }
                    }

                    await Task.Delay(1000);
                }

                requestContext.Complete(new Message("done"));
            }
        }
    }
}
