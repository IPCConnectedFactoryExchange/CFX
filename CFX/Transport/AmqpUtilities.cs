using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using System.IO;
using System.IO.Compression;
using CFX.Utilities;

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

            if (compressed) msg.Properties.ContentEncoding = "CFX-COMPRESSED";

            return msg;
        }

        public static Message MessageFromEnvelopes(IEnumerable<CFXEnvelope> envelopes, bool compressed = false)
        {
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
            byte [] compressedData = null;
            using (MemoryStream zip = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("CFXMessages.json");
                    using (BinaryWriter writer = new BinaryWriter(entry.Open()))
                    {
                        writer.Write(data);
                    }
                }

                compressedData = zip.ToArray();
            }

            return compressedData;
        }

        private static byte[] Decompress(byte[] data)
        {
            byte[] uncompressedData = null;
            using (MemoryStream zip = new MemoryStream(data))
            {
                using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.Entries.FirstOrDefault();
                    if (entry != null)
                    {
                        using (MemoryStream dataFile = new MemoryStream())
                        {
                            using (Stream s = entry.Open())
                            {
                                s.CopyTo(dataFile);
                                uncompressedData = dataFile.ToArray();
                            }
                        }
                    }
                }
            }

            return uncompressedData;
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
    }
}
