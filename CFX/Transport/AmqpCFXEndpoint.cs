using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using CFX.Utilities;

namespace CFX.Transport
{
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
        public event ValidateServerCertificateHandler OnValidateCertificate;

        public string CFXHandle
        {
            get;
            private set;
        }

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

        public void Open(string cfxHandle, IPAddress requestAddress, int requestPort = 5672)
        {
            Uri uri = new Uri(string.Format("amqp://{0}:{1}", requestAddress.ToString(), requestPort));
            Open(cfxHandle, uri);
        }

        public void Open(string cfxHandle, Uri requestUri = null)
        {
            IsOpen = false;

            try
            {
                this.CFXHandle = cfxHandle;
                if (requestUri != null)
                    this.RequestUri = requestUri;
                else
                    this.RequestUri = new Uri(string.Format("amqp://{0}:5672", EnvironmentHelper.GetMachineName()));

                //requestProcessor = new AmqpRequestProcessor();
                //requestProcessor.Open(this.CFXHandle, this.RequestUri);
                //requestProcessor.OnRequestReceived += RequestProcessor_OnRequestReceived;

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

        public void AddPublishChannel(AmqpChannelAddress address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null)
        {
            AddPublishChannel(address.Uri, address.Address, authMode, certificate);
        }

        public void AddPublishChannel(Uri networkAddress, string address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null)
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
                channel = new AmqpConnection(networkAddress, this, authMode, certificate);
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
                channel = channels[key];
                channel.RemoveChannel(address);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
        }

        public void AddSubscribeChannel(AmqpChannelAddress address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null)
        {
            AddSubscribeChannel(address.Uri, address.Address, authMode, certificate);
        }

        public void AddSubscribeChannel(Uri networkAddress, string address, AuthenticationMode authMode = AuthenticationMode.Auto, X509Certificate certificate = null)
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
                channel = new AmqpConnection(networkAddress, this, authMode, certificate);
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
                channel = channels[key];
                channel.RemoveChannel(address);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
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

        public CFXEnvelope ExecuteRequest(string targetUri, CFXEnvelope request)
        {
            CFXEnvelope response = null;
            Connection reqConn = null;
            Session reqSession = null;
            ReceiverLink receiver = null;
            SenderLink sender = null;
            Exception ex = null;
            Uri targetAddress = new Uri(targetUri);

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
                        reqConn = new Connection(new Address(targetAddress.ToString()));
                        reqSession = new Session(reqConn);
                        Attach recvAttach = new Attach()
                        {
                            Source = new Source() { Address = CFXHandle },
                            Target = new Target() { Address = request.Target }
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
                if (receiver != null && !receiver.IsClosed) receiver.Close();
                if (sender != null && !sender.IsClosed) sender.Close();
                if (reqSession != null && !reqSession.IsClosed) reqSession.Close();
                if (reqConn != null && !reqConn.IsClosed) reqConn.Close();
            }

            if (ex != null) throw ex;
            return response;
        }
    }
}
