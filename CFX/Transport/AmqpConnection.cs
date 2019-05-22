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
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace CFX.Transport
{
    internal class AmqpConnection : IDisposable
    {
        public AmqpConnection(Uri uri, AmqpCFXEndpoint endpoint, string virtualHostName = null, X509Certificate certificate = null)
        {
            SendTimout = TimeSpan.FromSeconds(5);
            links = new List<AmqpLink>();
            NetworkUri = uri;
            Endpoint = endpoint;
            Certificate = certificate;
            VirtualHostName = virtualHostName;
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

        public X509Certificate Certificate
        {
            get;
            set;
        }
        public string VirtualHostName
        {
            get;
            set;
        }

        public int TotalSpoolSize
        {
            get
            {
                return links.OfType<AmqpSenderLink>().Sum(l => l.Queue.Count);
            }
        }

        public int GetSpoolSize(string address)
        {
            return links.OfType<AmqpSenderLink>().Where(l => l.Address.ToUpper() == address.ToUpper()).Sum(l => l.Queue.Count);
        }

        public Connection InternalConnection
        {
            get
            {
                return connection;
            }
        }

        public Session InternalSession
        {
            get
            {
                return session;
            }
        }

        public event CFXMessageReceivedHandler OnCFXMessageReceived;
        public event ValidateServerCertificateHandler OnValidateCertificate;

        private Connection connection;
        private Session session;
        private List<AmqpLink> links;
        private bool connecting = false;

        public void OpenConnection()
        {
            Cleanup();

            Exception connectException = null;

            try
            {
                Open o = new Open()
                {
                    ContainerId = Endpoint.CFXHandle != null ? Endpoint.CFXHandle : Guid.NewGuid().ToString(),
                    HostName = VirtualHostName
                };

                ConnectionFactory factory = new ConnectionFactory();
                if (this.NetworkUri.Scheme.ToUpper() == "AMQPS") factory.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
                if (string.IsNullOrWhiteSpace(this.NetworkUri.UserInfo)) factory.SASL.Profile = SaslProfile.Anonymous;

                Task<Connection> t = factory.CreateAsync(new Address(NetworkUri.ToString()), o, null);
                t.Wait(5000);
                if (t.Status != TaskStatus.RanToCompletion)
                {
                    throw new Exception("Timeout on CreateAsync");
                }
                connection = t.Result;

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

            if (connectException != null)
            {
                Cleanup();
                throw connectException;
            }
        }

        protected bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            AppLog.Debug(string.Format("Validating remote certificate. Subject: {0}, Policy errors: {1}", certificate.Subject, sslPolicyErrors));

            if (OnValidateCertificate != null)
            {
                // Validate Certificate Externally
                ValidateCertificateResult result = OnValidateCertificate(NetworkUri, certificate, chain, sslPolicyErrors);
                if (result == ValidateCertificateResult.Valid) return true;
                if (result == ValidateCertificateResult.Invalid) return false;
            }

            if (certificate != null && Certificate != null)
            {
                byte[] key1 = certificate.GetPublicKey();
                byte[] key2 = Certificate.GetPublicKey();
                if (key1.SequenceEqual(key2)) return true;
            }

            return false;
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

        private AmqpLink FindLink(IAmqpObject o)
        {
            AmqpLink result = null;
            if (o is SenderLink) result = links.Where(l => l.Address == (o as SenderLink).Name).FirstOrDefault();
            if (o is ReceiverLink) result = links.Where(l => l.Address == (o as ReceiverLink).Name).FirstOrDefault();
            return result;
        }

        private void AmqpObject_Closed(IAmqpObject sender, Error error)
        {
            if (error != null)
            {
                PostConnectionEvent(ConnectionEvent.ConnectionInterrupted, new Exception(error.ToString()));
                AppLog.Error(string.Format("Connection LOST to endpoint {0}.\r\n\r\n{1}", NetworkUri.ToString(), error.ToString()));
                Close();
                EnsureConnection();
            }
            else
            {
                PostConnectionEvent(ConnectionEvent.ConnectionClosed);
            }
        }

        protected void EnsureConnection()
        {
            if (NetworkUri == null) return;

            bool madeConnections = false;
            bool connected = true;
            int newLinkCount = 0;
            Exception connectException = null;

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
                    connectException = ex;
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
                            connectException = ex;
                            connected = false;
                            AppLog.Error(ex);
                        }
                    }
                }

                if (connected && madeConnections) AppLog.Info($"{newLinkCount} Links established for {NetworkUri.ToString()}");
            }

            lock (this)
            {
                connecting = false;
            }

            if (!connected)
            {
                AppLog.Error($"Connection Failed for {NetworkUri.ToString()}.  Will attempt again in {AmqpCFXEndpoint.ReconnectInterval?.TotalSeconds} seconds...");
                PostConnectionEvent(ConnectionEvent.ConnectionFailed, connectException);
                Task.Run(new Action(async () =>
                {
                    await Task.Delay(Convert.ToInt32(AmqpCFXEndpoint.ReconnectInterval?.TotalMilliseconds));
                    EnsureConnection();
                }));
            }
            else
            {
                if (madeConnections) PostConnectionEvent(ConnectionEvent.ConnectionEstablished);
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
        public void AddPublishChannel(string address, bool connectImmediately = false)
        {
            lock (this)
            {
                if (links.Any(l => l.Address == address)) throw new Exception("A channel already exists for this address");

                AmqpSenderLink link = new AmqpSenderLink(NetworkUri, address, Endpoint.CFXHandle);
                links.Add(link);
            }

            if (connectImmediately) EnsureConnection();
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

            lock (this)
            {
                links.Remove(channel);
            }

            channel.CloseLink();
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

            if (envelopes == null || (envelopes != null && envelopes.Count < 1))
            {
                try
                {
                    receiver.Accept(message);
                    AppLog.Error(string.Format("Malformed Message Received:  {0}", AmqpUtilities.MessagePreview(message)));
                }
                catch (Exception ex)
                {
                    AppLog.Error(ex);
                }
            }
            else if (envelopes != null && OnCFXMessageReceived != null)
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

                if (session != null && !session.IsClosed)
                {
                    session.Close();
                }

                if (connection != null && !connection.IsClosed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
            session = null;
            connection = null;
        }

        internal void PostConnectionEvent(ConnectionEvent eventType, Exception error = null)
        {
            int spoolSize = TotalSpoolSize;
            Endpoint?.FirePostConnectionEvent(eventType, this.NetworkUri, spoolSize, error);
        }
    }

    public delegate void CFXMessageReceivedHandler(AmqpChannelAddress source, CFXEnvelope message);
    public delegate void CFXMessageReceivedFromListenerHandler(string targetAddress, CFXEnvelope message);
    public delegate ValidateCertificateResult ValidateServerCertificateHandler(Uri source, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);
    public delegate void ConnectionEventHandler(ConnectionEvent eventType, Uri uri, int spoolSize, string errorInformation, Exception errorException = null);
    
    public enum AuthenticationMode
    {
        Auto,
        Anonymous,
        External
    }

    public enum ValidateCertificateResult
    {
        Valid,
        Invalid,
        NotValidated
    }

    public enum ConnectionEvent
    {
        ConnectionEstablished,
        ConnectionFailed,
        ConnectionInterrupted,
        ConnectionClosed
    }
}
