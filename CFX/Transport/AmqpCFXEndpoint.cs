using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using CFX.Utilities;

namespace CFX.Transport
{
    /// <summary>
    /// Primary class used by endpoint implementers to facility bi-directional, AMQP 1.0 based communications.  Using this class, endpoints
    /// may publish messages to one or more destinations, subscribe to receive messages from one or more sources, and process incoming
    /// CFX requests from other CFX endpoints.  This class also supports security features, including secure AMQP 1.0 protocol (AMQPS or AMQP over TLS),
    /// as well as SASL based authentication (Simple Authentication and Security Layer).  At the time of this writing, the endpoint has been tested 
    /// and verified for use with the RabbitMQ broker (with AMQP 1.0 plug-in enabled), as well as the Apache Qpid broker.
    /// </summary>
    public class AmqpCFXEndpoint : IDisposable
    {
        public AmqpCFXEndpoint()
        {
            channels = new ConcurrentDictionary<string, AmqpConnection>();
            IsOpen = false;
            if (!UseCompression.HasValue) UseCompression = false;
            if (!ReconnectInterval.HasValue) ReconnectInterval = TimeSpan.FromSeconds(5);
            if (!KeepAliveEnabled.HasValue) KeepAliveEnabled = false;
            if (!KeepAliveInterval.HasValue) KeepAliveInterval = TimeSpan.FromSeconds(60);
            if (!MaxMessagesPerTransmit.HasValue) MaxMessagesPerTransmit = 30;
            if (!DurableReceiverSetting.HasValue) DurableReceiverSetting = 1;
            if (!DurableMessages.HasValue) DurableMessages = true;
            if (!RequestTimeout.HasValue) RequestTimeout = TimeSpan.FromSeconds(5);
        }

        private AmqpRequestProcessor requestProcessor;
        private ConcurrentDictionary<string, AmqpConnection> channels;

        public event OnRequestHandler OnRequestReceived;
        public event CFXMessageReceivedHandler OnCFXMessageReceived;
        public event CFXMessageReceivedFromListenerHandler OnCFXMessageReceivedFromListener;
        public event ValidateServerCertificateHandler OnValidateCertificate;

        /// <summary>
        /// Returns the CFXHandle of the endpoint currently associated with this AMQP endpoint.
        /// </summary>
        public string CFXHandle
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the Uri currently being used to accept incoming CFX requests for this endpoint
        /// </summary>
        public Uri RequestUri
        {
            get;
            private set;
        }

        // JJW:  Compression not fully implemented yet.  Private for now and not enabled.
        internal static bool? UseCompression
        {
            get;
            set;
        }
        public static TimeSpan? ReconnectInterval
        {
            get;
            set;
        }

        public static bool? KeepAliveEnabled
        {
            get;
            set;
        }

        public static TimeSpan? KeepAliveInterval
        {
            get;
            set;
        }

        public static TimeSpan? RequestTimeout
        {
            get;
            set;
        }

        public static int? MaxMessagesPerTransmit
        {
            get;
            set;
        }

        public static bool? DurableMessages
        {
            get;
            set;
        }

        public static uint? DurableReceiverSetting
        {
            get;
            set;
        }

        public bool IsOpen
        {
            get;
            private set;
        }

        public void Open(string cfxHandle, IPAddress requestAddress, int requestPort = 5672, X509Certificate2 certificate = null)
        {
            Uri uri = null;
            if (requestPort == 5673)
                uri = new Uri(string.Format("amqps://{0}:{1}", requestAddress.ToString(), requestPort));
            else
                uri = new Uri(string.Format("amqp://{0}:{1}", requestAddress.ToString(), requestPort));

            Open(cfxHandle, uri, certificate);
        }

        public void Open(string cfxHandle, Uri requestUri = null, X509Certificate2 certificate = null)
        {
            IsOpen = false;

            try
            {
                this.CFXHandle = cfxHandle;

                if (requestUri != null)
                {
                    this.RequestUri = requestUri;
                    requestProcessor = new AmqpRequestProcessor();
                    requestProcessor.Open(this.CFXHandle, this.RequestUri, certificate);
                    requestProcessor.OnRequestReceived += RequestProcessor_OnRequestReceived;
                    requestProcessor.OnMessageReceivedFromListener += RequestProcessor_OnCFXMessageReceivedFromListener;
                }

                IsOpen = true;
            }
            catch (Exception ex)
            {
                Cleanup();
                Debug.WriteLine(ex.Message);
            }
        }

        public bool TestChannel(Uri channelUri, AuthenticationMode authMode, out Exception error)
        {
            bool result = false;
            error = null;

            try
            {
                CFXHandle = Guid.NewGuid().ToString();
                AmqpConnection conn = new AmqpConnection(channelUri, this, authMode);
                conn.OpenConnection();
                conn.Close();
                result = true;
            }
            catch (Exception ex)
            {
                error = ex;
                Debug.WriteLine(ex.Message);
            }

            return result;
        }

        public void AddPublishChannel(AmqpChannelAddress address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null, string targetHostName = null)
        {
            AddPublishChannel(address.Uri, address.Address, authMode, certificate, targetHostName);
        }

        public void AddPublishChannel(Uri networkAddress, string address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null, string targetHostName = null)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                channel = channels[key];
            }
            else
            {
                channel = new AmqpConnection(networkAddress, this, authMode, certificate, targetHostName);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channel.OnValidateCertificate += Channel_OnValidateCertificate;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddPublishChannel(address);
            }
        }

        public void ClosePublishChannel(AmqpChannelAddress address)
        {
            ClosePublishChannel(address.Uri, address.Address);
        }

        public void ClosePublishChannel(Uri networkAddress, string address)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                while (!channels.TryRemove(key, out channel)) Task.Yield();
                channel.RemoveChannel(address);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
        }

        public void AddSubscribeChannel(AmqpChannelAddress address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null, string targetHostName = null)
        {
            AddSubscribeChannel(address.Uri, address.Address, authMode, certificate, targetHostName);
        }

        public void AddSubscribeChannel(Uri networkAddress, string address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null, string targetHostName = null)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                channel = channels[key];
            }
            else
            {
                channel = new AmqpConnection(networkAddress, this, authMode, certificate, targetHostName);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channel.OnValidateCertificate += Channel_OnValidateCertificate;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddSubscribeChannel(address);
            }
        }

        public void CloseSubscribeChannel(AmqpChannelAddress address)
        {
            CloseSubscribeChannel(address.Uri, address.Address);
        }

        public void CloseSubscribeChannel(Uri networkAddress, string address)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            string key = networkAddress.ToString();

            AmqpConnection channel = null;
            if (channels.ContainsKey(key))
            {
                while (!channels.TryRemove(key, out channel)) Task.Yield();
                channel.RemoveChannel(address);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
        }

        public void AddListener(string targetAddress)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to receive messages on a listener.");

            requestProcessor.AddListener(targetAddress);
        }

        public void CloseListener(string targetAddress)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to open or close a listener.");
            requestProcessor.RemoveListener(targetAddress);
        }

        private void Channel_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            OnCFXMessageReceived?.Invoke(source, message);
        }

        private ValidateCertificateResult Channel_OnValidateCertificate(Uri source, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (OnValidateCertificate != null)
            {
                return OnValidateCertificate(source, certificate, chain, sslPolicyErrors);
            }

            return ValidateCertificateResult.NotValidated;
        }

        private CFXEnvelope RequestProcessor_OnRequestReceived(CFXEnvelope request)
        {
            if (OnRequestReceived != null) return OnRequestReceived(request);
            return null;
        }

        private void RequestProcessor_OnCFXMessageReceivedFromListener(string targetAddress, CFXEnvelope message)
        {
            if (OnCFXMessageReceivedFromListener != null) OnCFXMessageReceivedFromListener(targetAddress, message);
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
            if (requestProcessor != null)
            {
                requestProcessor.Close();
                requestProcessor = null;
            }

            foreach (AmqpConnection conn in channels.Values)
            {
                conn.Dispose();
            }

            channels.Clear();
            IsOpen = false;
        }

        public void Publish(CFXEnvelope env)
        {
            FillSource(env);
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.Publish(env);
            }
        }

        public void Publish(CFXMessage msg)
        {
            CFXEnvelope env = new CFXEnvelope();
            env.MessageBody = msg;
            FillSource(env);
            Publish(env);
        }

        public void PublishMany(IEnumerable<CFXEnvelope> envelopes)
        {
            FillSource(envelopes);
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.PublishMany(envelopes);
            }
        }

        public void PublishMany(IEnumerable<CFXMessage> msgs)
        {
            List<CFXEnvelope> envelopes = new List<CFXEnvelope>();
            foreach (CFXMessage msg in msgs)
            {
                CFXEnvelope env = new CFXEnvelope();
                env.MessageBody = msg;
                FillSource(env);
                envelopes.Add(env);
            }

            PublishMany(envelopes);
        }

        private void FillSource(CFXEnvelope env)
        {
            if (env.Source == null) env.Source = this.CFXHandle;
        }

        private void FillSource(IEnumerable<CFXEnvelope> envelopes)
        {
            foreach (CFXEnvelope env in envelopes)
            {
                FillSource(env);
            }
        }

        private Uri CurrentRequestTargetUri
        {
            get;
            set;
        }

        public CFXEnvelope ExecuteRequest(string targetUri, CFXEnvelope request)
        {
            CFXEnvelope response = null;
            Connection reqConn = null;
            Session reqSession = null;
            ReceiverLink receiver = null;
            SenderLink sender = null;
            Exception ex = null;
            Uri targetAddress = new Uri(targetUri);
            CurrentRequestTargetUri = targetAddress;

            try
            {
                if (string.IsNullOrWhiteSpace(request.RequestID))
                {
                    request.RequestID = "REQUEST-" + Guid.NewGuid().ToString();
                }
                Message req = AmqpUtilities.MessageFromEnvelope(request, UseCompression.Value);
                req.Properties.MessageId = "command-request";
                req.Properties.ReplyTo = CFXHandle;
                req.ApplicationProperties = new ApplicationProperties();
                req.ApplicationProperties["offset"] = 1;

                Task.Run(() =>
                {
                    try
                    {
                        ConnectionFactory factory = new ConnectionFactory();
                        if (targetAddress.Scheme.ToLower() == "amqps")
                        {
                            factory.SSL.RemoteCertificateValidationCallback = ValidateRequestServerCertificate;
                            factory.SASL.Profile = SaslProfile.External;
                        }

                        if (string.IsNullOrWhiteSpace(targetAddress.UserInfo))
                        {
                            factory.SASL.Profile = SaslProfile.Anonymous;
                        }

                        reqConn = factory.CreateAsync(new Address(targetAddress.ToString())).Result;
                        //reqConn = new Connection(new Address(targetAddress.ToString()));
                        reqSession = new Session(reqConn);
                        Attach recvAttach = new Attach()
                        {
                            Source = new Source() { Address = request.Target },
                            Target = new Target() { Address = CFXHandle }
                        };

                        receiver = new ReceiverLink(reqSession, "request-receiver", recvAttach, null);
                        receiver.Start(300);
                        sender = new SenderLink(reqSession, CFXHandle, request.Target);

                        sender.Send(req);
                        Message resp = receiver.Receive(RequestTimeout.Value);
                        if (resp != null)
                        {
                            receiver.Accept(resp);
                            response = AmqpUtilities.EnvelopeFromMessage(resp);
                        }
                        else
                        {
                            throw new TimeoutException("A response was not received from target CFX endpoint in the alloted time.");
                        }
                    }
                    catch (Exception ex3)
                    {
                        AppLog.Error(ex3);
                        ex = ex3;
                    }
                }).Wait();
            }
            catch (Exception ex2)
            {
                AppLog.Error(ex2);
                if (ex == null) ex = ex2;
            }
            finally
            {
                if (receiver != null && !receiver.IsClosed) receiver.CloseAsync();
                if (sender != null && !sender.IsClosed) sender.CloseAsync();
                if (reqSession != null && !reqSession.IsClosed) reqSession.CloseAsync();
                if (reqConn != null && !reqConn.IsClosed) reqConn.CloseAsync();
            }

            if (ex != null)
            {
                if (ex.InnerException != null) throw ex.InnerException;
                throw ex;
            }

            return response;
        }

        bool ValidateRequestServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            ValidateCertificateResult result = ValidateCertificateResult.NotValidated;
            if (certificate != null && OnValidateCertificate != null)
            {
                result = OnValidateCertificate(CurrentRequestTargetUri, certificate, chain, sslPolicyErrors);
                if (result == ValidateCertificateResult.Invalid) return false;
            }

            return true;
        }
    }
}
