using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Amqp;
using Amqp.Framing;
using Amqp.Listener;
using System.Text;
using CFX.Utilities;

namespace CFX.Transport
{
    public class AmqpChannel : IDisposable
    {
        public AmqpChannel()
        {
            SendTimout = TimeSpan.FromSeconds(5);
        }

        public TimeSpan SendTimout
        {
            get;
            set;
        }

        public string CFXHandle
        {
            get;
            set;
        }

        public delegate void CFXMessageReceivedHandler(CFXEnvelope message);

        public event CFXMessageReceivedHandler OnCFXMessageReceived;
        
        private class Channel
        {
            public Connection outboundConnection;
            public Session outboundSession;
            public ReceiverLink outboundReceiver;
            public SenderLink outboundSender;
            public int linkCredit = 300;

            public void Close()
            {
                if (outboundReceiver != null) outboundReceiver.Close();
                if (outboundSender != null) outboundSender.Close();
                if (outboundSession != null) outboundSession.Close();
                if (outboundConnection != null) outboundConnection.Close();
            }
        }

        private Dictionary<string, Channel> channels = new Dictionary<string, Channel>();

        public void AddChannel(string address, string targetHandle)
        {
            if (channels.ContainsKey(targetHandle))
            {
                throw new ArgumentException("A channel with this name already exists.  Cannot add.");
            }

            var task = Task.Run(() =>
            {
                Channel c = new Channel();
                
                c.outboundConnection = new Amqp.Connection(new Address(address));
                c.outboundSession = new Session(c.outboundConnection);

                Attach recvAttach = new Attach()
                {
                    Source = new Source() { Address = targetHandle },
                    Target = new Target() { Address = this.CFXHandle + "-receiver" }
                };

                c.outboundReceiver = new ReceiverLink(c.outboundSession, CFXHandle + "-receiver", recvAttach, null);
                c.outboundReceiver.Start(c.linkCredit, OnMessageReceived);
                c.outboundSender = new SenderLink(c.outboundSession, CFXHandle, targetHandle);

                lock (this)
                {
                    channels[targetHandle] = c;
                }
            });

            Task.WaitAll(new Task[] { task });
        }

        public void CloseChannel(string targetHandle)
        {
            Channel c = null;

            lock (this)
            {
                if (!channels.ContainsKey(targetHandle))
                {
                    throw new ArgumentException("A channel with this name already exists.  Cannot add.");
                }

                c = channels[targetHandle];
                channels.Remove(targetHandle);
            }

            if (c != null) c.Close();
        }

        private int count = 0;

        public void Send(CFXEnvelope message, string replyTo, string targetHandle = null)
        {
            if (channels.Count < 1)
            {
                throw new Exception("No Channels Open");
            }

            var task = Task.Run(() =>
            {
                foreach (Channel c in channels.Values)
                {
                    byte[] data = message.ToBytes();
                    
                    Message request = new Message(data);
                    request.Properties = new Properties() { MessageId = "command-request", ReplyTo = CFXHandle + "-receiver"};
                    request.ApplicationProperties = new ApplicationProperties();
                    request.ApplicationProperties["offset"] = count;
                    c.outboundSender.Send(request, null, null);
                    

                    //Message msg = new Message(data);
                    //msg.Properties = new Properties() { MessageId = "command-request", ReplyTo = replyTo };
                    //msg.ApplicationProperties = new ApplicationProperties();
                    //msg.DeliveryAnnotations = new DeliveryAnnotations();
                    //msg.Header = new Header();
                    //msg.Footer = new Footer();
                    
                    //c.outboundSender.Send(msg, SendTimout);
                    //c.outboundSender.Send(msg, OnRequestResponse, null);
                }
            });

            Task.WaitAll(new Task[] { task });
        }

        private void OnRequestResponse(ILink sender, Message message, Outcome outcome, object state)
        {
            int z1 = 0;
        }

        public void CloseAll()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void OnMessageReceived(IReceiverLink receiver, Message message)
        {
            CFXEnvelope env = null;

            try
            {
                env = AmqpUtilities.EnvelopeFromMessage(message);
            }
            catch (Exception)
            {
                env = null;
            }

            if (env != null && OnCFXMessageReceived != null) OnCFXMessageReceived(env);
        }

        private void Cleanup()
        {
            lock (this)
            {
                channels.Values.ToList().ForEach(c => c.Close());
            }
        }

    }
}
