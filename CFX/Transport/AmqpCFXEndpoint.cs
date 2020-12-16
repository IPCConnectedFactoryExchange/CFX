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
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AmqpCFXEndpoint()
        {
            channels = new ConcurrentDictionary<string, AmqpConnection>();
            IsOpen = false;
            ValidateCertificates = true;
            HeartbeatFrequency = TimeSpan.FromMinutes(1);
            LastCertificate = null;
            LastUri = null;
            if (!Codec.HasValue) Codec = CFXCodec.gzip;
            if (!ReconnectInterval.HasValue) ReconnectInterval = TimeSpan.FromSeconds(5);
            if (!KeepAliveEnabled.HasValue) KeepAliveEnabled = false;
            if (!KeepAliveInterval.HasValue) KeepAliveInterval = TimeSpan.FromSeconds(60);
            if (!MaxMessagesPerTransmit.HasValue) MaxMessagesPerTransmit = 1;
            if (!DurableReceiverSetting.HasValue) DurableReceiverSetting = 1;
            if (!DurableMessages.HasValue) DurableMessages = true;
            if (!RequestTimeout.HasValue) RequestTimeout = TimeSpan.FromSeconds(30);
            if (!MaxFrameSize.HasValue) MaxFrameSize = 250000;
        }

        private AmqpRequestProcessor requestProcessor;
        private ConcurrentDictionary<string, AmqpConnection> channels;

        /// <summary>
        /// Event that fires whenever a request type CFX message is received by this Endpoint
        /// from another Endpoint.  Implement this event with your own handler to process incoming
        /// point-to-point Request / Response type CFX messages.
        /// </summary>
        public event OnRequestHandler OnRequestReceived;

        /// <summary>
        /// Event that fires whenever a CFX message is received from a subscription type channel.
        /// </summary>
        public event CFXMessageReceivedHandler OnCFXMessageReceived;

        /// <summary>
        /// Event that fires whenever a message is received that is not a valid, properly formatted CFX Message
        /// </summary>
        public event CFXMalformedMessageReceivedHandler OnMalformedMessageReceived;

        /// <summary>
        /// Event that fires whenever a CFX message is received from a listener type channel.
        /// </summary>
        public event CFXMessageReceivedFromListenerHandler OnCFXMessageReceivedFromListener;
        
        /// <summary>
        /// Implement this event with your own handler if you wish to validate the server certificate used for
        /// secure, encrypted, AMQPS communications.
        /// </summary>
        public event ValidateServerCertificateHandler OnValidateCertificate;

        /// <summary>
        /// Event that fires whenever a publish or subscription type connection is established, interrupted, or disconnected.
        /// The AmqpCFXEndpoint class will continuously attempt to reconnect any connection that has been 
        /// interrupted.
        /// </summary>
        public event ConnectionEventHandler OnConnectionEvent;

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

        /// <summary>
        /// Sets the codec used to transmit messages across the wire, including the newly introduced GZIP Compressed Codec, which is now the default.
        /// </summary>
        public static CFXCodec? Codec
        {
            get;
            set;
        }

        /// <summary>
        /// The time interval between attempts to reconnect publish or subscriber channels after a
        /// network interruption.  The default setting is false.
        /// </summary>
        public static TimeSpan? ReconnectInterval
        {
            get;
            set;
        }

        /// <summary>
        /// When enabled, the endpoint will automatically refresh (disconnect/reconnect) all of its
        /// subscription channels.  This is to prevent brokers from timing out the connection when
        /// the channel has been dormant for a period of time.  The default setting is 60 seconds.
        /// </summary>
        public static bool? KeepAliveEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// If keep alive is enabled, this property specifies the time period between keep alive reconnects.
        /// </summary>
        public static TimeSpan? KeepAliveInterval
        {
            get;
            set;
        }

        /// <summary>
        /// When executing a point to point request/response call to another CFX endpoint, this time span
        /// specifies the maximum amount of time that this endpoint will wait for the other endpoint to respond
        /// before timing out.  The default is 30 seconds.
        /// </summary>
        public static TimeSpan? RequestTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// When applicable, the endpoint will attempt to publish multiple messages in one AMQP transaction.
        /// This is done to maximize effeciency.  This property sets the maximum number of messages that may be
        /// grouped together in a single AMQP message.  The default value is 30 messages.
        /// </summary>
        public static int? MaxMessagesPerTransmit
        {
            get;
            set;
        }

        /// <summary>
        /// Used by the AMQP protocol to establish the maximum number of bytes to transmit per "frame" (aka "chunk").  
        /// Larger messages may be broken down into multiple frames if their size exceeds the max frame size.
        /// The default size is 500,000 bytes.
        /// </summary>
        public static int? MaxFrameSize
        {
            get;
            set;
        }

        /// <summary>
        /// Establishes the format for the subject property of the AMQP message envelope on all messages published 
        /// by this endpoint.  The following tags may be used in the format string:
        /// <list type="bullet">
        /// <item>${cfx-handle}      Will be replaced with the handle of your endpoint (CFXEnvelope.Source}</item>
        /// <item>${cfx-topic}       Will be replaced with the topic of the message ("CFX.Production" for example)</item>
        /// <item>${cfx-messagename} Will be replaced with the fully qualified name of the message ("CFX.Production.WorkStarted" for example)</item>
        /// </list>
        /// If this property is null or an empty string, the default subject format will be utilized:  "${cfx-handle}.${cfx-messagename}"
        /// </summary>
        public string SubjectFormat
        {
            get;
            set;
        }

        /// <summary>
        /// The AMQP 1.0 message framing header includes a "Durable" property that notifies recipients that this message
        /// should be maintained in durable storage on the message broker until delivered to all recipients, surviving broker system restarts.
        /// When this property is set to true, all messages published by the endpoint will be tagged with the Durable framing header.
        /// The default value is true.
        /// </summary>
        public static bool? DurableMessages
        {
            get;
            set;
        }

        /// <summary>
        /// Establishes the value of the Durable framing header flag for subscription channels.  Different brokers
        /// will interprety this value differently.  Refer to your broker documentation to determine how to set this flag.
        /// The default setting is 1 (which signals to RabbitMQ that durable messages should be removed from their queue
        /// once successfully delivered to this endpoint).
        /// </summary>
        public static uint? DurableReceiverSetting
        {
            get;
            set;
        }

        /// <summary>
        /// If set to false, certificate validation will be disabled.  This should only be used for testing purposes when a
        /// valid, commercial SSL certificate is not available for testing.
        /// </summary>
        public bool ValidateCertificates
        {
            get;
            set;
        }

        /// <summary>
        /// Read-only property indicating whether or not the endpoint is in an open state.
        /// </summary>
        public bool IsOpen
        {
            get;
            private set;
        }

        private TimeSpan heartbeatFrequency;

        /// <summary>
        /// The AmqpCFXEndpoint class automatically publishies CFX Heartbeat messages on 1 minute intervals by default.
        /// You can adjust this frequency using this property.  If set to zero (0), automatic publication of
        /// Heartbeat messages will be disabled.  The minimum frequency is 1 second and the maximum frequency is 5 minutes.
        /// </summary>
        public TimeSpan HeartbeatFrequency
        {
            get
            {
                return heartbeatFrequency;
            }
            set
            {
                if (value.TotalSeconds != 0 && (value.TotalSeconds < 1 || value.TotalMinutes > 5))
                {
                    throw new ArgumentOutOfRangeException("HeartBeatFrequency", $"Value must be greater than or equal to 1 seconds and less than or equal to 5 minutes.");
                }

                heartbeatFrequency = value;
                StartHeartbeat();
            }
        }

        private X509Certificate LastCertificate
        {
            get;
            set;
        }

        private Uri LastUri
        {
            get;
            set;
        }

        private System.Threading.Timer HeartbeatTimer
        {
            get;
            set;
        }

        private void StopHeartbeat()
        {
            if (HeartbeatTimer != null)
            {
                HeartbeatTimer.Dispose();
                HeartbeatTimer = null;
            }
        }

        private void StartHeartbeat()
        {
            lock (this)
            {
                StopHeartbeat();
                if (HeartbeatFrequency.TotalSeconds >= 1)
                {
                    HeartbeatTimer = new System.Threading.Timer((object state) =>
                    {
                        if (this.IsOpen)
                        {
                            Publish(new Heartbeat() { CFXHandle = this.CFXHandle, HeartbeatFrequency = this.HeartbeatFrequency });
                        }
                    }, null, 0, Convert.ToInt32(this.HeartbeatFrequency.TotalMilliseconds));
                }
            }
        }

        /// <summary>
        /// Opens and inintializes the Endpoint.  This should be called only once prior to closing the endpoint.
        /// </summary>
        /// <param name="cfxHandle">The unique CFX Handle for this endpoint.</param>
        /// <param name="requestAddress">The IP address on which this endpoint will listen for incoming requests.</param>
        /// <param name="requestPort">The TCP port on which this endpoint will listen for incoming requests.  Default is 5672.</param>
        /// <param name="certificate">An X509 certificate that has been loaded from the certificate store.  This is optional, and only must be set when using secure, encrypted AMQPS</param>
        public void Open(string cfxHandle, IPAddress requestAddress, int requestPort = 5672, X509Certificate2 certificate = null)
        {
            Uri uri = null;
            if (requestPort == 5673)
                uri = new Uri(string.Format("amqps://{0}:{1}", requestAddress.ToString(), requestPort));
            else
                uri = new Uri(string.Format("amqp://{0}:{1}", requestAddress.ToString(), requestPort));

            Open(cfxHandle, uri, certificate);
        }

        /// <summary>
        /// Opens and inintializes the Endpoint.  This should be called only once prior to closing the endpoint.
        /// </summary>
        /// <param name="cfxHandle">The unique CFX Handle for this endpoint.</param>
        /// <param name="requestUri">The Uri / network address on which this endpoint will listen for incoming requests for this endpoint.  amqp:// prefix
        /// may be used for unencrypted AMQP on port 5672.  amqps:// prefix may be used for secure AMQP on port 5671.  You may also specify
        /// custom ports using normal hostname:port notation.  Authentication may also be specified using standard user notation:  eg.
        /// amqps://user1:password1@myhost/
        /// </param>
        /// <param name="certificate">An X509 certificate that has been loaded from the certificate store.  This is optional, and only must be set when using secure, encrypted AMQPS</param>
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
                    requestProcessor.Open(this, certificate);
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

        /// <summary>
        /// Tests if the specified network address is capable of establishing an AMQP connection from this endpoint.
        /// </summary>
        /// <param name="channelUri">The network address of the target channel.</param>
        /// <param name="virtualHostName">The name of the virtual host at the destination endpoint.  Default is null for default virtual host.</param>
        /// <param name="error">In the case of an error, returns information about the nature of the error.</param>
        /// <returns></returns>
        public bool TestChannel(Uri channelUri, out Exception error, string virtualHostName = null)
        {
            error = null;
            Connection conn = null;
            Session sess = null;
            Exception ex = null;

            try
            {
                Open o = new Open()
                {
                    ContainerId = Guid.NewGuid().ToString(),
                    HostName = virtualHostName,
                    MaxFrameSize = (uint)AmqpCFXEndpoint.MaxFrameSize.Value
                };

                ConnectionFactory fact = new ConnectionFactory();
                if (string.IsNullOrWhiteSpace(channelUri.UserInfo))
                {
                    fact.SASL.Profile = SaslProfile.Anonymous;
                }

                Task<Connection> tConn = fact.CreateAsync(new Address(channelUri.ToString()), o);
                tConn.Wait(3000);
                if (tConn.Status != TaskStatus.RanToCompletion) throw new Exception("Timeout");

                conn = tConn.Result;
                conn.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                sess = new Session(conn);
                sess.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                if (ex != null) throw ex;
                Task.Delay(10).Wait();
                if (ex != null) throw ex;
            }
            catch (Exception ex2)
            {
                error = ex2;
                Debug.WriteLine(ex2.Message);
            }
            finally
            {
                if (sess != null && !sess.IsClosed) sess.CloseAsync();
                if (conn != null && !conn.IsClosed) conn.CloseAsync();
            }

            if (error == null) return true;
            return false;
        }


        /// <summary>
        /// Tests if the specified network address and AMQP target address is capable of receiving messages published from this endpoint.
        /// </summary>
        /// <param name="networkAddress">The network address of the target channel.</param>
        /// <param name="address">The AMQP target address to which messages will be published.</param>
        /// <param name="error">In the case of an error, returns information about the nature of the error.</param>
        /// <param name="virtualHostName">The name of the virtual host at the destination endpoint.  Default is null for default virtual host.  For RabbitMQ broker, use format vhost:MYVHOST</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <returns>A boolean value indicated whether or not the channel is valid.</returns>
        public bool TestPublishChannel(Uri networkAddress, string address, out Exception error, string virtualHostName = null, X509Certificate certificate = null)
        {
            error = null;
            Connection conn = null;
            Session sess = null;
            SenderLink link = null;
            Exception ex = null;

            try
            {
                Open o = new Open()
                {
                    ContainerId = Guid.NewGuid().ToString(),
                    HostName = virtualHostName,
                    MaxFrameSize = (uint)AmqpCFXEndpoint.MaxFrameSize.Value
                };

                ConnectionFactory fact = new ConnectionFactory();
                if (string.IsNullOrWhiteSpace(networkAddress.UserInfo))
                {
                    fact.SASL.Profile = SaslProfile.Anonymous;
                }

                if (networkAddress.Scheme.ToUpper() == "AMQPS")
                {
                    LastCertificate = certificate;
                    LastUri = networkAddress;
                    fact.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
                }
                                
                Task<Connection> tConn = fact.CreateAsync(new Address(networkAddress.ToString()), o);
                tConn.Wait(3000);
                if (tConn.Status != TaskStatus.RanToCompletion) throw new Exception("Timeout");

                conn = tConn.Result;
                conn.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                sess = new Session(conn);
                sess.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                if (ex != null) throw ex;
                link = new SenderLink(sess, address, address);
                link.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                link.Close();
                Task.Delay(10).Wait();
                if (ex != null) throw ex;
            }
            catch (Exception ex2)
            {
                error = ex2;
                Debug.WriteLine(ex2.Message);
            }
            finally
            {
                if (sess != null && !sess.IsClosed) sess.CloseAsync();
                if (conn != null && !conn.IsClosed) conn.CloseAsync();
            }

            if (error == null) return true;
            return false;
        }

        /// <summary>
        /// Tests if this endpoint is capable of subscribing to and receiving message from the specified network address and AMQP source address.
        /// </summary>
        /// <param name="networkAddress">The network address of the target channel.</param>
        /// <param name="address">The AMQP source address from which messages will be received.</param>
        /// <param name="error">In the case of an error, returns information about the nature of the error.</param>
        /// <param name="virtualHostName">The name of the virtual host at the destination endpoint.  Default is null for default virtual host.  For RabbitMQ broker, use format vhost:MYVHOST</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <returns>A boolean value indicated whether or not the channel is valid.</returns>
        public bool TestSubscribeChannel(Uri networkAddress, string address, out Exception error, string virtualHostName = null, X509Certificate certificate = null)
        {
            error = null;
            Connection conn = null;
            Session sess = null;
            ReceiverLink link = null;
            Exception ex = null;

            try
            {
                Open o = new Open()
                {
                    ContainerId = Guid.NewGuid().ToString(),
                    HostName = virtualHostName,
                    MaxFrameSize = (uint)AmqpCFXEndpoint.MaxFrameSize.Value
                };

                Amqp.Framing.Source source = new Amqp.Framing.Source()
                {
                    Address = address,
                    Durable = AmqpCFXEndpoint.DurableReceiverSetting.Value
                };

                ConnectionFactory fact = new ConnectionFactory();
                if (string.IsNullOrWhiteSpace(networkAddress.UserInfo))
                {
                    fact.SASL.Profile = SaslProfile.Anonymous;
                }

                if (networkAddress.Scheme.ToUpper() == "AMQPS")
                {
                    LastCertificate = certificate;
                    LastUri = networkAddress;
                    fact.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
                }

                Task<Connection> tConn = fact.CreateAsync(new Address(networkAddress.ToString()), o);
                tConn.Wait(3000);
                if (tConn.Status != TaskStatus.RanToCompletion) throw new Exception("Timeout");

                conn = tConn.Result;
                conn.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                sess = new Session(conn);
                sess.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                if (ex != null) throw ex;
                link = new ReceiverLink(sess, address, source, null);
                link.Closed += (IAmqpObject s, Error e) => { if (e != null) ex = new Exception(e.Description); };
                link.Close();
                Task.Delay(10).Wait();
                if (ex != null) throw ex;
            }
            catch (Exception ex2)
            {
                error = ex2;
                Debug.WriteLine(ex2.Message);
            }
            finally
            {
                if (sess != null && !sess.IsClosed) sess.CloseAsync();
                if (conn != null && !conn.IsClosed) conn.CloseAsync();
            }

            if (error == null) return true;
            return false;
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            AppLog.Debug(string.Format("Validating remote certificate. Subject: {0}, Policy errors: {1}", certificate.Subject, sslPolicyErrors));

            if (!ValidateCertificates) return true;
            
            if (OnValidateCertificate != null)
            {
                // Validate Certificate Externally
                ValidateCertificateResult result = OnValidateCertificate(LastUri, certificate, chain, sslPolicyErrors);
                if (result == ValidateCertificateResult.Valid) return true;
                if (result == ValidateCertificateResult.Invalid) return false;
            }

            if (certificate != null && LastCertificate != null)
            {
                byte[] key1 = certificate.GetPublicKey();
                byte[] key2 = LastCertificate.GetPublicKey();
                if (key1.SequenceEqual(key2)) return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a new publish channel for this endpoint.  All messages published by the endpoint will be transmitted to one or more publish channels that
        /// are established using this method.  Only call this methoud after this endpoint has been opened by the Open method.
        /// </summary>
        /// <param name="address">Represents the network address and AMQP target address of the target channel</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <param name="virtualHostName">If using a broker with multiple virtual hosts, the virtual host name to be used on the broker.</param>
        public void AddPublishChannel(AmqpChannelAddress address, string virtualHostName = null, X509Certificate certificate = null)
        {
            AddPublishChannel(address.Uri, address.Address, virtualHostName, certificate);
        }

        /// <summary>
        /// Adds a new publish channel for this endpoint.  All messages published by the endpoint will be transmitted to one or more publish channels that
        /// are established using this method.  Only call this methoud after this endpoint has been opened by the Open method.
        /// </summary>
        /// <param name="networkAddress">The network address of the target channel.</param>
        /// <param name="address">The AMQP target address of the target channel.</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <param name="virtualHostName">If using a broker with multiple virtual hosts, the virtual host name to be used on the broker.  For RabbitMQ broker, use format vhost:MYVHOST</param>
        public void AddPublishChannel(Uri networkAddress, string address, string virtualHostName = null, X509Certificate certificate = null)
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
                channel = new AmqpConnection(networkAddress, this, virtualHostName, certificate);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channel.OnValidateCertificate += Channel_OnValidateCertificate;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddPublishChannel(address);
                
                if (this.HeartbeatFrequency != TimeSpan.Zero)
                {
                    CFXEnvelope env = new CFXEnvelope(new Heartbeat() { CFXHandle = this.CFXHandle, HeartbeatFrequency = this.HeartbeatFrequency });
                    FillSource(env);
                    channel.Publish(env);
                }
            }
        }

        /// <summary>
        /// Closes the specified publish channel (that was opened previously via a call to AddPublishChannel.
        /// </summary>
        /// <param name="address">The channel address to be closed.</param>
        public void ClosePublishChannel(AmqpChannelAddress address)
        {
            ClosePublishChannel(address.Uri, address.Address);
        }

        /// <summary>
        /// Closes the specified publish channel (that was opened previously via a call to AddPublishChannel.
        /// </summary>
        /// <param name="networkAddress">The network address of the channel to be closed.</param>
        /// <param name="address">The AMQP target address of the channel to be closed.</param>
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

        /// <summary>
        /// Adds a new subscription channel for this endpoint.
        /// </summary>
        /// <param name="address">The address (network address + AMQP source address) of the source.</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <param name="virtualHostName">If using a broker with multiple virtual hosts, the virtual host name to be used on the broker.</param>
        public void AddSubscribeChannel(AmqpChannelAddress address, string virtualHostName = null, X509Certificate certificate = null)
        {
            AddSubscribeChannel(address.Uri, address.Address, virtualHostName, certificate);
        }

        /// <summary>
        /// Adds a new subscription channel for this endpoint.
        /// </summary>
        /// <param name="networkAddress">The network address of the message source.</param>
        /// <param name="address">The AMQP source address of the message source.</param>
        /// <param name="certificate">If secure amqps is being used, this property may optionally include the certificate that will be matched
        /// against the server's certificate.  Leave null if you do not wish to perform certificate matching (secure communications will still be established
        /// using the server's certificate (if using amqps).</param>
        /// <param name="virtualHostHame">If using a broker with multiple virtual hosts, the virtual host name to be used on the broker.  For RabbitMQ broker, use format vhost:MYVHOST</param>
        public void AddSubscribeChannel(Uri networkAddress, string address, string virtualHostHame = null, X509Certificate certificate = null)
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
                channel = new AmqpConnection(networkAddress, this, virtualHostHame, certificate);
                channel.OnCFXMessageReceived += Channel_OnCFXMessageReceived;
                channel.OnValidateCertificate += Channel_OnValidateCertificate;
                channels[key] = channel;
            }

            if (channel != null)
            {
                channel.AddSubscribeChannel(address);
            }
        }

        /// <summary>
        /// Closes the specified subscription channel (that was opened previously via a call to AddSubscribeChannel.
        /// </summary>
        /// <param name="address">The channel address to be closed.</param>
        public void CloseSubscribeChannel(AmqpChannelAddress address)
        {
            CloseSubscribeChannel(address.Uri, address.Address);
        }

        /// <summary>
        /// Closes the specified subscription channel (that was opened previously via a call to AddSubscribeChannel.
        /// </summary>
        /// <param name="networkAddress"></param>
        /// <param name="address"></param>
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

        /// <summary>
        /// Allows this endpoint to listen for and receive unsolicited (published) messages directly from multiple CFX endpoints that have been configured to publish messages to this
        /// endpoint, just like a message broker.  Your endpoint must be configured to receive requests (via the Open method requestUri parameter) before adding a listener.
        /// </summary>
        /// <param name="targetAddress">The AMQP target address on which to receive messages (like a broker exchange address).</param>
        public void AddListener(string targetAddress)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to receive messages on a listener.");

            requestProcessor.AddListener(targetAddress);
        }

        /// <summary>
        /// Closes a previously added listener (added with AddListener method).
        /// </summary>
        /// <param name="targetAddress">The AMQP target address to close.</param>
        public void CloseListener(string targetAddress)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to open or close a listener.");
            requestProcessor.RemoveListener(targetAddress);
        }

        /// <summary>
        /// Set up a message source on this endpoint that other endpoints may subscribe to.  Messages published to a message source are placed in a queue, and remain there until
        /// a subscriber connects and removes them.  The queue is volatile, and will be deleted when the hosting process is restarted.
        /// </summary>
        /// <param name="sourceAddress"></param>
        public void AddMessageSource(string sourceAddress)
        {
            if (!IsOpen) throw new Exception("The Endpoint must be open before adding or removing channels.");
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to act as a message source.");

            requestProcessor.AddSource(sourceAddress);
        }

        /// <summary>
        /// Closes a previously added message source.  All messages in the source's queue will be purged upon closing.
        /// </summary>
        /// <param name="sourceAddress"></param>
        public void CloseMessageSource(string sourceAddress)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have a request processor set up via the Open method in order to open or close a message source.");
            requestProcessor.RemoveSource(sourceAddress);
        }

        /// <summary>
        /// Purges all queued messages for the given message source.
        /// </summary>
        /// <param name="sourceAddress"></param>
        public void PurgeMessageSource(string sourceAddress)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to open or close a message source.");
            requestProcessor.PurgeSource(sourceAddress);
        }

        /// <summary>
        /// Publishes a single message to a message source.
        /// </summary>
        /// <param name="sourceAddress"></param>
        /// <param name="env"></param>
        public void PublishToMessageSource(string sourceAddress, CFXEnvelope env)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to publish to a message source.");

            FillSource(env);
            requestProcessor.PublishToSource(sourceAddress, new CFXEnvelope[] { env });
        }

        /// <summary>
        /// Publishes multiple messages to a message source.
        /// </summary>
        /// <param name="sourceAddress"></param>
        /// <param name="envelopes"></param>
        public void PublishManyToMessageSource(string sourceAddress, IEnumerable<CFXEnvelope> envelopes)
        {
            if (requestProcessor == null || !requestProcessor.IsOpen) throw new Exception("The Endpoint must have an a request processor set up via the Open method in order to publish to a message source.");

            FillSource(envelopes);
            requestProcessor.PublishToSource(sourceAddress, envelopes);
        }

        private void Channel_OnCFXMessageReceived(AmqpChannelAddress source, CFXEnvelope message)
        {
            OnCFXMessageReceived?.Invoke(source, message);
        }

        internal void Channel_OnMalformedMessageReceived(AmqpChannelAddress source, string message)
        {
            OnMalformedMessageReceived?.Invoke(source, message);
        }

        private ValidateCertificateResult Channel_OnValidateCertificate(Uri source, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (!ValidateCertificates) return ValidateCertificateResult.Valid;

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

        /// <summary>
        /// Returns the total number of messages spooled for a particular 
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public int GetSpoolSize(AmqpChannelAddress addr)
        {
            string key = addr.Uri.ToString();
            
            if (channels.ContainsKey(key))
            {
                return channels[key].GetSpoolSize(addr.Address);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
        }

        /// <summary>
        /// Permanently deletes all spooled messages from the specified Publish channel.
        /// </summary>
        /// <param name="addr">The channel address of the publish channel to be purged.</param>
        public void PurgeSpool(AmqpChannelAddress addr)
        {
            string key = addr.Uri.ToString();

            if (channels.ContainsKey(key))
            {
                channels[key].PurgeSpool(addr);
            }
            else
            {
                throw new ArgumentException("The specified channel does not exist.");
            }
        }

        /// <summary>
        /// Permanently deletes all spooled messages from all Publish channels associated with this endpoint.
        /// </summary>
        public void PurgeAllSpools()
        {
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.PurgeAllSpools();
            }
        }

        /// <summary>
        /// Publishes a CFX message.  The message will be transmitted to all publish channels.
        /// </summary>
        /// <param name="env">The CFX envelope containing the message to publish.</param>
        public void Publish(CFXEnvelope env)
        {
            FillSource(env);
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.Publish(env);
            }
        }

        /// <summary>
        /// Publishes a CFX message.  A CFX envelope will be automatically generated for
        /// your message.  The message will be transmitted to all publish channels.
        /// </summary>
        /// <param name="msg">The CFX message to publish.</param>
        public void Publish(CFXMessage msg)
        {
            CFXEnvelope env = new CFXEnvelope();
            env.MessageBody = msg;
            FillSource(env);
            Publish(env);
        }

        /// <summary>
        /// Publishes multiple CFX messages at one time.  The messages will be transmitted to all publish channels.
        /// </summary>
        /// <param name="envelopes"></param>
        public void PublishMany(IEnumerable<CFXEnvelope> envelopes)
        {
            FillSource(envelopes);
            foreach (AmqpConnection channel in channels.Values)
            {
                channel.PublishMany(envelopes);
            }
        }

        /// <summary>
        /// Publishes multiple CFX messages at one time. CFX envelopes will be automatically generated
        /// for your messages.  The messages will be transmitted to all publish channels.
        /// </summary>
        /// <param name="msgs"></param>
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

        /// <summary>
        /// Performs a direct, point-to-point request/response transaction with another CFX Endpoint.
        /// </summary>
        /// <param name="targetUri">The network address of the Endpoint to which the request will be sent.
        /// May use amqp:// or amqps:// topic (amqps for secure communications).
        /// May also include user information (for authentication), as well as a custom TCP port.
        /// </param>
        /// <param name="request">A CFX envelope containing the request.</param>
        /// <returns>A CFX envelope containing the response from the Endpoint.</returns>
        public CFXEnvelope ExecuteRequest(string targetUri, CFXEnvelope request)
        {
            return ExecuteRequestAsync(targetUri, request)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Performs a direct, point-to-point request/response transaction with another CFX Endpoint.
        /// </summary>
        /// <param name="targetUri">The network address of the Endpoint to which the request will be sent.
        /// May use amqp:// or amqps:// topic (amqps for secure communications).
        /// May also include user information (for authentication), as well as a custom TCP port.
        /// </param>
        /// <param name="request">A CFX envelope containing the request.</param>
        /// <returns>A CFX envelope containing the response from the Endpoint.</returns>
        public async Task<CFXEnvelope> ExecuteRequestAsync(string targetUri, CFXEnvelope request)
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
                if (string.IsNullOrWhiteSpace(request.Source))
                {
                    request.Source = CFXHandle;
                }

                Message req = AmqpUtilities.MessageFromEnvelope(request, Codec.Value);
                req.Properties.MessageId = "command-request";
                req.Properties.ReplyTo = CFXHandle;
                req.ApplicationProperties = new ApplicationProperties();
                req.ApplicationProperties["offset"] = 1;
                
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

                    reqConn = await factory.CreateAsync(new Address(targetAddress.ToString())).ConfigureAwait(false);
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
            }
            catch (Exception ex2)
            {
                AppLog.Error(ex2);
                if (ex == null) ex = ex2;
            }
            finally
            {
                if (receiver != null && !receiver.IsClosed) await receiver.CloseAsync().ConfigureAwait(false);
                if (sender != null && !sender.IsClosed) await sender.CloseAsync().ConfigureAwait(false);
                if (reqSession != null && !reqSession.IsClosed) await reqSession.CloseAsync().ConfigureAwait(false);
                if (reqConn != null && !reqConn.IsClosed) await reqConn.CloseAsync().ConfigureAwait(false);
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

        internal void FirePostConnectionEvent(ConnectionEvent eventType, Uri uri, int spoolSize, Exception error = null)
        {
            OnConnectionEvent?.Invoke(eventType, uri, spoolSize, error?.Message, error);
        }
    }
}
