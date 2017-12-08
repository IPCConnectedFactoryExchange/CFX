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
    internal class AmqpConnection : IDisposable
    {
        public AmqpConnection()
        {
            SendTimout = TimeSpan.FromSeconds(5);
            senders = new List<SenderLink>();
            receivers = new List<ReceiverLink>();
            UseCompression = false;
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

        public bool UseCompression
        {
            get;
            set;
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


            Task.Run(() =>
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
            }).Wait();

            if (connectException != null)
            {
                Cleanup();
                throw connectException;
            }
        }

        public void OpenPublishChannel(string address)
        {
            if (!IsOpen) throw new Exception("The connection is not open.  Cannot add a transmit channel on a closed connection.");
            Exception addException = null;

            Task.Run(() =>
            {
                try
                {
                    SenderLink sender = new SenderLink(session, address, address);
                    lock (this)
                    {
                        senders.Add(sender);
                    }
                }
                catch (Exception ex)
                {
                    addException = ex;
                    Debug.WriteLine(ex.Message);
                    Cleanup();
                }
            }).Wait();

            if (addException != null) throw addException;
        }


        public void OpenSubscribeChannel(string address)
        {
            if (!IsOpen) throw new Exception("The connection is not open.  Cannot add a receive channel on a closed connection.");
            Exception addException = null;

            Task.Run(() =>
            {
                try
                {
                    ReceiverLink receiver = new ReceiverLink(session, address, address);
                    receiver.Start(linkCredit, OnMessageReceived);
                    lock (this)
                    {
                        receivers.Add(receiver);
                    }
                }
                catch (Exception ex)
                {
                    addException = ex;
                    Debug.WriteLine(ex.Message);
                    Cleanup();
                }
            }).Wait();

            if (addException != null) throw addException;
        }

        public void ClosePublishChannel(string address)
        {
            SenderLink channel = senders.Where(s => s.Name == address).FirstOrDefault();
            if (channel == null) throw new ArgumentException("There is no open channel named " + address);

            channel.Close();

            lock (this)
            {
                senders.Remove(channel);
            }
        }

        public void CloseSubscribeChannel(string address)
        {
            ReceiverLink channel = receivers.Where(s => s.Name == address).FirstOrDefault();
            if (channel == null) throw new ArgumentException("There is no open channel named " + address);

            channel.Close();

            lock (this)
            {
                receivers.Remove(channel);
            }
        }

        public void Close()
        {
            Cleanup();
        }

        public void Publish(CFXEnvelope env, string replyTo = null)
        {
            Exception sendException = null;

            var task = Task.Run(() =>
            {
                foreach (SenderLink sender in senders)
                {
                    try
                    {
                        Message msg = AmqpUtilities.MessageFromEnvelope(env, UseCompression);
                        if (!string.IsNullOrEmpty(replyTo)) msg.Properties.ReplyTo = replyTo;
                        sender.Send(msg, SendTimout);
                    }
                    catch (Exception ex)
                    {
                        sendException = ex;
                        Debug.WriteLine(ex.Message);
                        Cleanup();
                    }
                }
            });

            Task.WaitAll(new Task[] { task });

            if (sendException != null) throw sendException;
        }

        public void PublishMany(IEnumerable<CFXEnvelope> envelopes)
        {
            Exception sendException = null;

            var task = Task.Run(() =>
            {
                foreach (SenderLink sender in senders)
                {
                    try
                    {
                        Message msg = AmqpUtilities.MessageFromEnvelopes(envelopes, UseCompression);
                        sender.Send(msg, SendTimout);
                    }
                    catch (Exception ex)
                    {
                        sendException = ex;
                        Debug.WriteLine(ex.Message);
                        Cleanup();
                    }
                }
            });

            Task.WaitAll(new Task[] { task });

            if (sendException != null) throw sendException;
        }

        private void OnMessageReceived(IReceiverLink receiver, Message message)
        {
            List<CFXEnvelope> envelopes = null;

            try
            { 
               envelopes = AmqpUtilities.EnvelopesFromMessage(message);
            }
            catch (Exception)
            {
                envelopes = null;
            }

            if (envelopes != null && OnCFXMessageReceived != null)
            {
                receiver.Accept(message);
                envelopes.ForEach(env => OnCFXMessageReceived(new AmqpChannelAddress() { Uri = NetworkUri, Address = receiver.Name }, env));
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

            lock (this)
            {
                receivers.Clear();
                senders.Clear();
            }

            session = null;
            connection = null;
        }
    }

    public delegate void CFXMessageReceivedHandler(AmqpChannelAddress source, CFXEnvelope message);
}
