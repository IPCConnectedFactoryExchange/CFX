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

        public void PurgeSpool(AmqpChannelAddress addr)
        {
            foreach (AmqpSenderLink sender in links.Where(l => l.Address.ToUpper() == addr.Address.ToUpper()).OfType<AmqpSenderLink>())
            {
                sender.PurgeSpool();
            }
        }

        public void PurgeAllSpools()
        {
            foreach (AmqpSenderLink sender in links.OfType<AmqpSenderLink>())
            {
                sender.PurgeSpool();
            }
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
                    HostName = VirtualHostName,
                    MaxFrameSize = (uint)AmqpCFXEndpoint.MaxFrameSize.Value
                };

                ConnectionFactory factory = new ConnectionFactory();
#if !NETSTANDARD1_6
                if (this.NetworkUri.Scheme.ToUpper() == "AMQPS") factory.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
#endif
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

                AmqpSenderLink link = new AmqpSenderLink(NetworkUri, address, Endpoint.CFXHandle, this);
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

        public void Publish(CFXEnvelope env)
        {
            EnsureConnection();

            foreach (AmqpSenderLink sender in links.OfType<AmqpSenderLink>())
            {
                sender.Publish(new CFXEnvelope[] { env });
            }
        }

        public void PublishToChannel(CFXEnvelope env, string address)
        {
            EnsureConnection();

            AmqpSenderLink link = links.OfType<AmqpSenderLink>().Where(l => l.Address == address).FirstOrDefault();
            if (link == null) throw new ArgumentException("There is no active publish channel that matches the specified channel address", "address");

            link.Publish(new CFXEnvelope[] { env });
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
                    Endpoint?.Channel_OnMalformedMessageReceived(new AmqpChannelAddress() { Uri = NetworkUri, Address = receiver.Name }, AmqpUtilities.StringFromEnvelopes(message));
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

    /// <summary>
    /// Delegate for CFX Message received events from subscribed channels
    /// </summary>
    /// <param name="source">The source of the message</param>
    /// <param name="message">The envelope containing the message</param>
    public delegate void CFXMessageReceivedHandler(AmqpChannelAddress source, CFXEnvelope message);

    /// <summary>
    /// Delegate for malformed CFX Message received events
    /// </summary>
    /// <param name="source">The source of the message</param>
    /// <param name="message">The text that was received that is not a valid CFX message</param>
    public delegate void CFXMalformedMessageReceivedHandler(AmqpChannelAddress source, string message);

    /// <summary>
    /// Delegate for published messages received via self-hosted exchanges
    /// </summary>
    /// <param name="targetAddress">The AMQP target that was specified by the publisher</param>
    /// <param name="message">The CFX envelope containing the published message</param>
    public delegate void CFXMessageReceivedFromListenerHandler(string targetAddress, CFXEnvelope message);

    /// <summary>
    /// Delegate for certificate self-validation
    /// </summary>
    /// <param name="source">The Uri of the source</param>
    /// <param name="certificate">The certificate</param>
    /// <param name="chain">The certification chain</param>
    /// <param name="sslPolicyErrors">Policy Errors</param>
    /// <returns></returns>
    public delegate ValidateCertificateResult ValidateServerCertificateHandler(Uri source, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);

    /// <summary>
    /// Delegate for connection related events
    /// </summary>
    /// <param name="eventType">The type of event</param>
    /// <param name="uri">The related Uri</param>
    /// <param name="spoolSize">The current size of the related spool (message count)</param>
    /// <param name="errorInformation">Human interpretable information related to the event</param>
    /// <param name="errorException">An optional Exception indicating error details</param>
    public delegate void ConnectionEventHandler(ConnectionEvent eventType, Uri uri, int spoolSize, string errorInformation, Exception errorException = null);
    
    /// <summary>
    /// An enumeration indicating the authentication mode
    /// </summary>
    public enum AuthenticationMode
    {
        /// <summary>
        /// Authentication is handled automatically
        /// </summary>
        Auto,
        /// <summary>
        /// Anonymous authentication shoudl be utilized
        /// </summary>
        Anonymous,
        /// <summary>
        /// External authentication should be utilized
        /// </summary>
        External
    }

    /// <summary>
    /// An enumeration that indicates the result of an SSL certificate validation
    /// </summary>
    public enum ValidateCertificateResult
    {
        /// <summary>
        /// The certificate is valid
        /// </summary>
        Valid,
        /// <summary>
        /// The certificate is not valid
        /// </summary>
        Invalid,
        /// <summary>
        /// The certificate was not validated.  Apply default validation.
        /// </summary>
        NotValidated
    }

    /// <summary>
    /// An enumeration that indicates the type of a connection event
    /// </summary>
    public enum ConnectionEvent
    {
        /// <summary>
        /// Connection with established successfully
        /// </summary>
        ConnectionEstablished,
        /// <summary>
        /// Connection could not be established
        /// </summary>
        ConnectionFailed,
        /// <summary>
        /// Connection was previously established, but has been interrupted
        /// </summary>
        ConnectionInterrupted,
        /// <summary>
        /// Connection has been ended
        /// </summary>
        ConnectionClosed
    }
}
