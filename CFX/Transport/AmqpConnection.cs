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
    class AmqpConnection : IDisposable
    {
        public AmqpConnection()
        {
            SendTimout = TimeSpan.FromSeconds(5);
            senders = new List<SenderLink>();
            receivers = new List<ReceiverLink>();
        }

        public TimeSpan SendTimout
        {
            get;
            set;
        }

        public Uri NetworkUri
        {
            get;
            private set;
        }

        public bool IsOpen
        {
            get
            {
                return (connection != null && !connection.IsClosed);
            }
        }

        public event CFXMessageReceivedHandler OnCFXMessageReceived;

        private Connection connection;
        private Session session;
        private List<ReceiverLink> receivers;
        private List<SenderLink> senders;
        private int linkCredit = 300;

        public void Open(Uri networkAddress)
        {
            Cleanup();
            NetworkUri = networkAddress;
            
            Exception connectException = null;

            var task = Task.Run(() =>
            {
                try
                {
                    connection = new Amqp.Connection(new Address(NetworkUri.ToString()));
                    session = new Session(connection);
                }
                catch (Exception ex)
                {
                    connectException = ex;
                    Debug.WriteLine(ex.Message);
                    Cleanup();
                }
            });

            Task.WaitAll(new Task[] { task });

            if (connectException != null)
            {
                Cleanup();
                throw connectException;
            }
        }

        public void AddTransmitChannel(string address)
        {
            if (!IsOpen) throw new Exception("The connection is not open.  Cannot add a transmit channel on a closed connection.");
            Exception addException = null;

            var task = Task.Run(() =>
            {
                try
                {
                    SenderLink sender = new SenderLink(session, address, address);
                    senders.Add(sender);
                }
                catch (Exception ex)
                {
                    addException = ex;
                    Debug.WriteLine(ex.Message);
                    Cleanup();
                }
            });

            Task.WaitAll(new Task[] { task });

            if (addException != null) throw addException;
        }


        public void AddReceiverChannel(string address)
        {
            if (!IsOpen) throw new Exception("The connection is not open.  Cannot add a receive channel on a closed connection.");
            Exception addException = null;

            var task = Task.Run(() =>
            {
                try
                {
                    ReceiverLink receiver = new ReceiverLink(session, address, address);
                    receiver.Start(linkCredit, OnMessageReceived);
                    receivers.Add(receiver);
                }
                catch (Exception ex)
                {
                    addException = ex;
                    Debug.WriteLine(ex.Message);
                    Cleanup();
                }
            });

            Task.WaitAll(new Task[] { task });

            if (addException != null) throw addException;
        }

        public void Close()
        {
            Cleanup();
        }

        public void Send(CFXEnvelope env, string replyTo = null)
        {
            var task = Task.Run(() =>
            {
                foreach (SenderLink sender in senders)
                {
                    Message msg = AmqpUtilities.MessageFromEnvelope(env);
                    if (!string.IsNullOrEmpty(replyTo)) msg.Properties.ReplyTo = replyTo;
                    sender.Send(msg, SendTimout);
                }
            });

            Task.WaitAll(new Task[] { task });
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

            if (env != null && OnCFXMessageReceived != null)
            {
                OnCFXMessageReceived(new AmqpChannelAddress() { Uri = NetworkUri, Address = receiver.Name }, env);
                receiver.Accept(message);
            }
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            try
            {
                receivers.ForEach(r => r.Close());
                senders.ForEach(s => s.Close());
                if (session != null) session.Close();
                if (connection != null) connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            receivers.Clear();
            senders.Clear();
            session = null;
            connection = null;
        }
    }

    public delegate void CFXMessageReceivedHandler(AmqpChannelAddress source, CFXEnvelope message);
}
