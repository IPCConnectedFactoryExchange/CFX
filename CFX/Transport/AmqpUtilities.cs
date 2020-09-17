using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using System.IO;
using System.IO.Compression;
using CFX.Utilities;
using System.Security.Cryptography.X509Certificates;
using Amqp.Framing;

namespace CFX.Transport
{
    /// <summary>
    /// An enumeration that describes the encoding method that will be used to serialize/deserialize
    /// CFX messages for transmission across the wire.  Similar to Content-Encoding header in HTTP,
    /// </summary>
    public enum CFXCodec
    {
        /// <summary>
        /// Messages are transmitted uncompressed in raw JSON format with UTF-8 encoding
        /// </summary>
        raw = 0,
        /// <summary>
        /// Messages are transmitted in compressed GZIP format
        /// </summary>
        gzip = 1
    }

    public static class AmqpUtilities
    {
        public static Message MessageFromEnvelope(CFXEnvelope env, CFXCodec codec = CFXCodec.raw, string subjectFormat = null)
        {
            byte[] msgData = Encode(env.ToBytes(), codec);

            Message msg = new Message(msgData);
            SetHeaders(msg, env, codec, subjectFormat);

            return msg;
        }

        public static Message MessageFromEnvelopes(CFXEnvelope [] envelopes, CFXCodec codec = CFXCodec.raw, string subjectFormat = null)
        {
            if (envelopes.Length < 1)
            {
                return null;
            }
            else if (envelopes.Length == 1)
            {
                return MessageFromEnvelope(envelopes.First(), codec, subjectFormat);
            }

            CFXEnvelope env = envelopes.First();
            List<CFXEnvelope> container = new List<CFXEnvelope>(envelopes);
            byte[] msgData = Encoding.UTF8.GetBytes(CFXJsonSerializer.SerializeObject(container));
            msgData = Encode(msgData, codec);

            Message msg = new Message(msgData);
            SetHeaders(msg, env, codec, subjectFormat);
            
            return msg;
        }

        private static void SetHeaders(Message msg, CFXEnvelope env, CFXCodec codec, string subjectFormat)
        {
            msg.Header = new Amqp.Framing.Header()
            {
                Durable = AmqpCFXEndpoint.DurableMessages.Value
            };

            msg.Properties = new Amqp.Framing.Properties
            {
                MessageId = env.UniqueID.ToString(),
                To = env.Target,
                ReplyTo = env.Source,
                CorrelationId = env.RequestID,
                ContentType = "application/json; charset=\"utf-8\"",
                CreationTime = env.TimeStamp,
            };

            if (string.IsNullOrWhiteSpace(subjectFormat))
            {
                msg.Properties.Subject = $"{env.Source}.{env.MessageName}";
            }
            else
            {
                msg.Properties.Subject = subjectFormat.Replace("${cfx-handle}", env.Source);
                msg.Properties.Subject = msg.Properties.Subject.Replace("${cfx-topic}", env.MessageBody.GetType().Namespace);
                msg.Properties.Subject = msg.Properties.Subject.Replace("${cfx-messagename}", env.MessageName);
            }

            if (codec == CFXCodec.gzip) msg.Properties.ContentEncoding = "gzip";

            msg.ApplicationProperties = new ApplicationProperties();
            msg.ApplicationProperties["cfx-topic"] = env.MessageBody.GetType().Namespace;
            msg.ApplicationProperties["cfx-message"] = env.MessageName;
            msg.ApplicationProperties["cfx-handle"] = env.Source;
            msg.ApplicationProperties["cfx-target"] = env.Target;
        }

        public static List<CFXEnvelope> EnvelopesFromMessage(Message msg)
        {
            if (msg.Body is byte[])
            {
                byte[] msgData = msg.Body as byte[];
                CFXCodec codec = CFXCodec.raw;
                if (string.Compare(msg.Properties.ContentEncoding, "gzip", true) == 0) codec = CFXCodec.gzip;
                msgData = Decode(msgData, codec);

                List<CFXEnvelope> results;

                string jsonData = Encoding.UTF8.GetString(msgData);
                if (IsMessageList(jsonData))
                {
                    results = CFXEnvelope.FromJsonList(jsonData);
                }
                else
                {
                    results = new List<CFXEnvelope>( new CFXEnvelope [] { CFXEnvelope.FromJson(jsonData) });
                }

                return results;
            }

            throw new ArgumentException("AMQP Message Body does not contain a valid CFX Envelope");

        }

        public static string StringFromEnvelopes(Message msg)
        {
            if (msg?.Body is byte[])
            {
                return Encoding.UTF8.GetString(msg.Body as byte[]);
            }
            else if (msg?.Body is string)
            {
                return msg.Body as string;
            }

            return null;
        }

        public static bool IsMessageList(string jsonData)
        {
            string test = jsonData.Substring(0, jsonData.Length >= 20 ? 20 : jsonData.Length).TrimStart();
            if (test.StartsWith("[")) return true;
            return false;
        }

        public static CFXEnvelope EnvelopeFromMessage(Message msg)
        {
            if (msg.Body is byte[])
            {
                byte[] msgData = msg.Body as byte[];
                CFXCodec codec = CFXCodec.raw;
                if (string.Compare(msg.Properties.ContentEncoding, "gzip", true) == 0) codec = CFXCodec.gzip;
                msgData = Decode(msgData, codec);
                return CFXEnvelope.FromBytes(msgData);
            }

            throw new ArgumentException("AMQP Message Body does not contain a valid CFX Envelope");
        }

        private static byte[] Encode(byte[] data, CFXCodec codec = CFXCodec.raw)
        {
            byte[] result = null;

            if (codec == CFXCodec.gzip)
            {
                using (MemoryStream output = new MemoryStream())
                {
                    using (MemoryStream input = new MemoryStream(data))
                    using (GZipStream dstream = new GZipStream(output, CompressionMode.Compress))
                    {
                        input.CopyTo(dstream);
                    }

                    result = output.ToArray();
                }

                AppLog.Debug($"GZIP Compressed Message(s) of Size {data.Length} bytes to {result.Length} bytes");
            }
            else
            {
                result = data;
            }

            return result;
        }

        private static byte[] Decode(byte[] data, CFXCodec codec = CFXCodec.raw)
        {
            byte[] result = null;

            if (codec == CFXCodec.gzip)
            {
                using (MemoryStream output = new MemoryStream())
                {
                    using (MemoryStream input = new MemoryStream(data))
                    using (GZipStream dstream = new GZipStream(input, CompressionMode.Decompress))
                    {
                        dstream.CopyTo(output);
                    }

                    result = output.ToArray();
                }
            }
            else
            {
                result = data;
            }

            return result;
        }

        public static string MessagePreview(Message message, int count = 200)
        {
            if (message.Body is byte [])
            {
                byte[] bt = message.Body as byte[];
                string result = "";
                try
                {
                    result = Encoding.UTF8.GetString(bt);
                    if (result.Length > count) result = result.Substring(0, count);
                }
                catch (Exception)
                {
                    for (int i = 0; i < bt.Length && i < count; i++)
                    {
                        result += string.Format("0x{0:X2", bt[i]);
                    }
                }

                result += "...";
                return result;
            }
            else if (message.Body is string)
            {
                string result = message.Body as string;
                if (result.Length > count) result = result.Substring(0, count);
                result += "...";
                return result;
            }

            return "";
        }

        public static X509Certificate2 GetCertificate(string certFindValue)
        {
            StoreLocation[] locations = new StoreLocation[] { StoreLocation.LocalMachine, StoreLocation.CurrentUser };
            foreach (StoreLocation location in locations)
            {
                X509Store store = new X509Store(StoreName.My, location);
                store.Open(OpenFlags.OpenExistingOnly);

                X509Certificate2Collection collection = store.Certificates.Find(
                    X509FindType.FindBySubjectName,
                    certFindValue,
                    false);

                if (collection.Count == 0)
                {
                    collection = store.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        certFindValue,
                        false);
                }

                store.Dispose();
                
                if (collection.Count > 0)
                {
                    return collection[0];
                }
            }

            throw new ArgumentException("No certificate can be found using the find value " + certFindValue);
        }

        private static byte[] Compress2(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            using (GZipStream dstream = new GZipStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }

            return output.ToArray();
        }

        private static byte[] Decompress2(byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (GZipStream dstream = new GZipStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

        public static bool SendAzureAuthenticationToken(Connection connection, string host, string shareAccessSignature, string audience)
        {
            bool result = true;
            Session session = new Session(connection);

            string cbsReplyToAddress = "cbs-reply-to";
            var cbsSender = new SenderLink(session, "cbs-sender", "$cbs");
            var cbsReceiver = new ReceiverLink(session, cbsReplyToAddress, "$cbs");

            // construct the put-token message
            var request = new Message(shareAccessSignature);
            request.Properties = new Properties();
            request.Properties.MessageId = Guid.NewGuid().ToString();
            request.Properties.ReplyTo = cbsReplyToAddress;
            request.ApplicationProperties = new ApplicationProperties();
            request.ApplicationProperties["operation"] = "put-token";
            request.ApplicationProperties["type"] = "azure-devices.net:sastoken";
            request.ApplicationProperties["name"] = audience;
            cbsSender.Send(request);

            // receive the response
            var response = cbsReceiver.Receive();
            if (response == null || response.Properties == null || response.ApplicationProperties == null)
            {
                result = false;
            }
            else
            {
                int statusCode = (int)response.ApplicationProperties["status-code"];
                string statusCodeDescription = (string)response.ApplicationProperties["status-description"];
                if (statusCode != (int)202 && statusCode != (int)200) // !Accepted && !OK
                {
                    result = false;
                }
            }

            // the sender/receiver may be kept open for refreshing tokens
            cbsSender.Close();
            cbsReceiver.Close();
            session.Close();

            return result;
        }

        private static readonly long UtcReference = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks;

        public static string GetSharedAccessSignature(string keyName, string sharedAccessKey, string resource, TimeSpan tokenTimeToLive)
        {
            // http://msdn.microsoft.com/en-us/library/azure/dn170477.aspx
            // the canonical Uri scheme is http because the token is not amqp specific
            // signature is computed from joined encoded request Uri string and expiry string

            string expiry = ((long)(DateTime.UtcNow - new DateTime(UtcReference, DateTimeKind.Utc) + tokenTimeToLive).TotalSeconds).ToString();
            string encodedUri = HttpUtility.UrlEncode(resource);

            byte[] hmac = SHA.computeHMAC_SHA256(Convert.FromBase64String(sharedAccessKey), Encoding.UTF8.GetBytes(encodedUri + "\n" + expiry));
            string sig = Convert.ToBase64String(hmac);

            if (keyName != null)
            {
                return Fx.Format(
                "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                encodedUri,
                HttpUtility.UrlEncode(sig),
                HttpUtility.UrlEncode(expiry),
                HttpUtility.UrlEncode(keyName));
            }
            else
            {
                return Fx.Format(
                    "SharedAccessSignature sr={0}&sig={1}&se={2}",
                    encodedUri,
                    HttpUtility.UrlEncode(sig),
                    HttpUtility.UrlEncode(expiry));
            }
        }
    }
}
