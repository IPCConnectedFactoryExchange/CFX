using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Amqp;
using Amqp.Framing;
using Amqp.Listener;
using Amqp.Sasl;
using System.Text;
using CFX.Utilities;

namespace CFX.Transport
{
    internal class AmqpConnection : IDisposable
    {
        public AmqpConnection(Uri uri, AmqpCFXEndpoint endpoint)
        {
            SendTimout = TimeSpan.FromSeconds(5);
            links = new List<AmqpLink>();
            NetworkUri = uri;
            Endpoint = endpoint;
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

        public AmqpCFXEndpoint Endpoint
        {
            get;
            private set;
        }

        public bool IsClosed
        {
            get
            {
                return (connection == null || (connection != null && connection.IsClosed));
            }
        }

        public event CFXMessageReceivedHandler OnCFXMessageReceived;

        private Connection connection;
        private Session session;
        private List<AmqpLink> links;
        private bool connecting = false;
        private bool closing = false;

        public void OpenConnection()
        {
            Cleanup();

            Exception connectException = null;

            Task.Run(() =>
            {
                try
                {
                    //ConnectionFactory factory = new ConnectionFactory();
                    //factory.SASL.Profile = SaslProfile.Anonymous;
                    Open o = new Open()
                    {
                        ContainerId = Endpoint.CFXHandle != null ? Endpoint.CFXHandle : Guid.NewGuid().ToString(),
                    };
                    //connection = await factory.CreateAsync(new Address(NetworkUri.ToString()), o, null);
                    connection = new Connection(new Address(NetworkUri.ToString()), SaslProfile.Anonymous, o, null);
                    connection.Closed += AmqpObject_Closed;
                    session = new Session(connection);
                    session.Closed += AmqpObject_Closed;
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

        private Timer keepAliveTimer = null;
        private object keepAliveLock = new object();
        
        private void KeepAliveTimer(object o)
        {
            AppLog.Info(string.Format("Keep Alive Timer Firing for endpoint {0} ...", NetworkUri.ToString()));

            lock (this)
            {
                foreach (AmqpReceiverLink link in links.OfType<AmqpReceiverLink>())
                {
                    link.CloseLink();
                }
            }

            EnsureConnection();
        }

        private void AmqpObject_Closed(IAmqpObject sender, Error error)
        {
            if (!closing)
            {
                if (error != null)
                {
                    AppLog.Error(string.Format("Connection LOST to endpoint {0}.\r\n\r\n{1}", NetworkUri.ToString(), error.ToString()));
                    EnsureConnection();
                }
            }
        }

        protected void EnsureConnection()
        {
            if (NetworkUri == null) return;

            bool madeConnections = false;
            bool connected = true;
            int newLinkCount = 0;

            lock (this)
            {
                if (connecting) return;
                connecting = true;
            }

            if (IsClosed)
            {
                connected = false;

                try
                {
                    AppLog.Info("Connecting to " + NetworkUri.ToString());
                    OpenConnection();
                    madeConnections = true;
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                }
            }

            if (!IsClosed)
            {
                connected = true;

                if (madeConnections) AppLog.Info("Connected to " + NetworkUri.ToString() + ".  Establishing Links...");

                lock (this)
                {
                    foreach (AmqpLink link in links.Where(l => l.IsClosed))
                    {
                        try
                        {
                            link.CreateLink(session, this.OnMessageReceived);
                            madeConnections = true;
                            ++newLinkCount;
                        }
                        catch (Exception ex)
                        {
                            connected = false;
                            AppLog.Error(ex);
                        }
                    }
                }

                if (connected && madeConnections) AppLog.Info(string.Format("{0} Links established for {1}", newLinkCount, NetworkUri.ToString()));
            }

            lock (this)
            {
                connecting = false;
            }

            if (!connected)
            {
                AppLog.Error(string.Format("Connection Failed for {0}.  Will attempt again in {1} seconds...", NetworkUri.ToString(), AmqpCFXEndpoint.ReconnectInterval?.TotalSeconds));
                Task.Run(new Action(() =>
                {
                    Thread.Sleep(Convert.ToInt32(AmqpCFXEndpoint.ReconnectInterval?.TotalMilliseconds));
                    EnsureConnection();
                }));
            }
            else
            {
                if (AmqpCFXEndpoint.KeepAliveEnabled.Value)
                {
                    lock (keepAliveLock)
                    {
                        if (keepAliveTimer == null)
                        {
                            int interval = Convert.ToInt32(AmqpCFXEndpoint.KeepAliveInterval.Value.TotalMilliseconds);
                            keepAliveTimer = new Timer(new TimerCallback(KeepAliveTimer), null, 0, interval);
                        }
                    }
                }
            }
        }
        public void AddPublishChannel(string address)
        {
            lock (this)
            {
                if (links.Any(l => l.Address == address)) throw new Exception("A channel already exists for this address");

                AmqpSenderLink link = new AmqpSenderLink(NetworkUri, address);
                links.Add(link);
            }
        }

        public void AddSubscribeChannel(string address)
        {
            lock (this)
            {
                if (links.Any(l => l.Address == address)) throw new Exception("A channel already exists for this address");

                AmqpReceiverLink link = new AmqpReceiverLink(address);
                links.Add(link);
            }

            EnsureConnection();
        }

        public void RemoveChannel(string address)
        {
            AmqpLink channel = links.Where(s => s.Address == address).FirstOrDefault();
            if (channel == null) return;

            channel.CloseLink();

            lock (this)
            {
                links.Remove(channel);
            }
        }

        public void Close()
        {
            StopKeepAliveTimer();
            Cleanup();
        }

        public void Publish(CFXEnvelope env, string replyTo = null)
        {
            EnsureConnection();

            foreach (AmqpSenderLink sender in links.OfType<AmqpSenderLink>())
            {
                sender.Publish(new CFXEnvelope[] { env });
            }
        }

        public void PublishMany(IEnumerable<CFXEnvelope> envelopes)
        {
            EnsureConnection();

            foreach (AmqpSenderLink sender in links.OfType<AmqpSenderLink>())
            {
                sender.Publish(envelopes.ToArray());
            }
        }

        private void PublishInternal(CFXEnvelope[] envelopes)
        {
            EnsureConnection();

            List<AmqpSenderLink> senderLinks = new List<AmqpSenderLink>(links.OfType<AmqpSenderLink>());
            foreach (AmqpSenderLink sender in senderLinks.OfType<AmqpSenderLink>())
            {
                sender.Publish(envelopes);
            }
        }

        private void OnMessageReceived(IReceiverLink receiver, Message message)
        {
            List<CFXEnvelope> envelopes = null;

            try
            { 
               envelopes = AmqpUtilities.EnvelopesFromMessage(message);
            }
            catch (Exception ex)
            {
                envelopes = null;
                AppLog.Error(ex);
            }

            if (envelopes != null && OnCFXMessageReceived != null)
            {
                try
                {
                    receiver.Accept(message);
                    envelopes.ForEach(env => OnCFXMessageReceived(new AmqpChannelAddress() { Uri = NetworkUri, Address = receiver.Name }, env));
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                }
            }
        }

        public void Dispose()
        {
            StopKeepAliveTimer();
            Cleanup();
        }

        private void StopKeepAliveTimer()
        {
            lock (keepAliveLock)
            {
                if (keepAliveTimer != null) keepAliveTimer.Dispose();
                keepAliveTimer = null;
            }
        }

        private void Cleanup()
        {
            try
            {
                links.ForEach(l => l.CloseLink());

                if (session != null && !session.IsClosed) session.Close();
                if (connection != null && !connection.IsClosed)
                {
                    closing = true;
                    connection.Close();
                    closing = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            
            session = null;
            connection = null;
        }
    }

    public delegate void CFXMessageReceivedHandler(AmqpChannelAddress source, CFXEnvelope message);
}
