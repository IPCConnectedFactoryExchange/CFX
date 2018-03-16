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
    public static class AmqpUtilities
    {
        public static Message MessageFromEnvelope(CFXEnvelope env, bool compressed = false)
        {
            byte[] msgData = env.ToBytes();
            if (compressed)
            {
                msgData = Compress(msgData);
            }

            Message msg = new Message(msgData);
            msg.Properties = new Amqp.Framing.Properties
            {
                MessageId = env.UniqueID.ToString(),
                CreationTime = env.TimeStamp
            };
            msg.Header = new Amqp.Framing.Header()
            {
                Durable = AmqpCFXEndpoint.DurableMessages.Value
            };
            
            if (compressed) msg.Properties.ContentEncoding = "CFX-COMPRESSED";

            return msg;
        }

        public static Message MessageFromEnvelopes(CFXEnvelope [] envelopes, bool compressed = false)
        {
            if (envelopes.Length == 1)
            {
                return MessageFromEnvelope(envelopes.First());
            }

            List<CFXEnvelope> container = new List<CFXEnvelope>(envelopes);
            byte[] msgData = Encoding.UTF8.GetBytes(CFXJsonSerializer.SerializeObject(container));
            if (compressed)
            {
                msgData = Compress(msgData);
            }

            Message msg = new Message(msgData);
            msg.Properties = new Amqp.Framing.Properties
            {
                MessageId = Guid.NewGuid().ToString(),
                CreationTime = DateTime.Now
            };
            msg.Header = new Amqp.Framing.Header()
            {
                Durable = AmqpCFXEndpoint.DurableMessages.Value
            };
            
            if (compressed) msg.Properties.ContentEncoding = "CFX-COMPRESSED";

            return msg;
        }

        public static List<CFXEnvelope> EnvelopesFromMessage(Message msg)
        {
            if (msg.Body is byte[])
            {
                byte[] msgData = msg.Body as byte[];
                if (msg.Properties?.ContentEncoding == "CFX-COMPRESSED")
                {
                    msgData = Decompress(msgData);
                }

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
                if (msg.Properties?.ContentEncoding == "CFX-COMPRESSED")
                {
                    msgData = Decompress(msgData);
                }

                return CFXEnvelope.FromBytes(msgData);
            }

            throw new ArgumentException("AMQP Message Body does not contain a valid CFX Envelope");
        }

        private static byte[] Compress(byte[] data)
        {
            // JJW:  No Compression for now.
            return data;
            
            //byte [] compressedData = null;
            //using (MemoryStream zip = new MemoryStream())
            //{
            //    using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Update))
            //    {
            //        ZipArchiveEntry entry = archive.CreateEntry("CFXMessages.json");
            //        using (BinaryWriter writer = new BinaryWriter(entry.Open()))
            //        {
            //            writer.Write(data);
            //        }
            //    }

            //    compressedData = zip.ToArray();
            //}

            //return compressedData;
        }

        private static byte[] Decompress(byte[] data)
        {
            // JJW:  No compression for now.
            return data;
            
            //byte[] uncompressedData = null;
            //using (MemoryStream zip = new MemoryStream(data))
            //{
            //    using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Read))
            //    {
            //        ZipArchiveEntry entry = archive.Entries.FirstOrDefault();
            //        if (entry != null)
            //        {
            //            using (MemoryStream dataFile = new MemoryStream())
            //            {
            //                using (Stream s = entry.Open())
            //                {
            //                    s.CopyTo(dataFile);
            //                    uncompressedData = dataFile.ToArray();
            //                }
            //            }
            //        }
            //    }
            //}

            //return uncompressedData;
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
