using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using CFX.Utilities;

#pragma warning disable 1591

namespace CFX
{
    /// <summary>
    /// The <see cref="CFXEnvelope"/> class is the outer envelope or container in which all CFX messages are enclosed for transmission.
    /// Common properties, such as a globally unique identifier (ID) and the timestamp for the message (TimeStamp),
    /// are defined by this container class and are included with all CFX message transmissions.
    /// <code language="none">
    /// {
    ///    "MessageName": "CFX.EndpointConnected",
    ///    "Version": "1.2",
    ///    "TimeStamp": "2018-03-26T16:52:25.3769532-04:00",
    ///    "UniqueID": "f3b2c8ec-50b7-4c63-9cb3-2ed57c01880f",
    ///    "Source": null,
    ///    "Target": null,
    ///    "RequestID": null,
    ///    "MessageBody": {
    ///      "CFXHandle": "SMTPlus.Model_21232.SN23123",
    ///      "RequestNetworkUri": "amqp://host33/",
    ///      "RequestTargetAddress": "/queue/SN23123"
    ///     }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CFXEnvelope
    {
        public CFXEnvelope()
        {
            UniqueID = Guid.NewGuid();
            Version = CFXVERSION;
            TimeStamp = DateTime.Now;
            QueueFilePosition = -1;
            Transmitted = false;
        }

        public const string CFXVERSION = "1.1";
        
        public CFXEnvelope(Type messageType) : this()
        {
            MessageBody = Activator.CreateInstance(messageType);
        }

        public CFXEnvelope(string messageType) : this()
        {
            MessageBody = Activator.CreateInstance(Type.GetType(messageType));
        }

        public CFXEnvelope(CFXMessage message) : this()
        {
            MessageBody = message;
        }

        public static CFXEnvelope FromTypeName(string messageType)
        {
            return new CFXEnvelope(messageType);
        }

        private string messageName;

        [JsonProperty]
        public string MessageName
        {
            get
            {
                if (MessageBody == null) return null;
                return messageName;
            }
            private set
            {
                messageName = value;
            }
        }

        [JsonProperty]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty]
        public DateTime TimeStamp
        {
            get;
            set;
        }

        [JsonProperty]
        public Guid UniqueID
        {
            get;
            set;
        }
               
        [JsonProperty]
        public string Source
        {
            get;
            set;
        }

        [JsonProperty]
        public string Target
        {
            get;
            set;
        }

        [JsonProperty]
        public string RequestID
        {
            get;
            set;
        }

        private object messageBody;

        /// <summary>
        /// The message payload (The CFX message enclosed in this envelope).
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public object MessageBody
        {
            get
            {
                return messageBody;
            }
            set
            {
                messageBody = value;
                if (messageBody != null && MessageBody.GetType().FullName.StartsWith("CFX."))
                {
                    MessageName = messageBody.GetType().FullName;
                    Version = CFXVERSION;
                }
            }
        }

        public T GetMessage<T>()
        {
            return (T)MessageBody;
        }

        public string ToJson(bool formatted = false)
        {
            return CFXJsonSerializer.SerializeObject(this, formatted);
        }

        public static CFXEnvelope FromCFXMessage(CFXMessage msg)
        {
            return new CFXEnvelope(msg);
        }

        public static CFXEnvelope FromJson(string jsonData)
        {
            CFXEnvelope env = CFXJsonSerializer.DeserializeObject<CFXEnvelope>(jsonData);

            // For backwards compatibility.  Older versions of the SDK did not properly decorate the $type of the MessageBody property,
            // so the message portion had to be deserialized individually, which was inefficient.
            if (!(env.MessageBody is CFXMessage))
            {
                Type tp = Type.GetType(env.MessageName);
                env.MessageBody = CFXJsonSerializer.DeserializeObject(env.MessageBody.ToString(), tp);
            }

            return env;
        }

        public static List<CFXEnvelope> FromJsonList(string jsonData)
        {
            List<CFXEnvelope> list = CFXJsonSerializer.DeserializeObject<List<CFXEnvelope>>(jsonData);
            foreach (CFXEnvelope env in list)
            {
                // For backwards compatibility.  Older versions of the SDK did not properly decorate the $type of the MessageBody property,
                // so the message portion had to be deserialized individually, which was inefficient.
                if (!(env.MessageBody is CFXMessage))
                {
                    Type tp = Type.GetType(env.MessageName);
                    env.MessageBody = CFXJsonSerializer.DeserializeObject(env.MessageBody.ToString(), tp);
                }
            }

            return list;
        }

        private long QueueFilePosition
        {
            get;
            set;
        }

        internal bool Transmitted
        {
            get;
            set;
        }

        internal static CFXEnvelope ReadRecord(BinaryReader reader)
        {
            try
            {
                long filePosition = reader.BaseStream.Position;
                bool transmitted = reader.ReadBoolean();
                Int32 len = reader.ReadInt32();
                byte[] data = reader.ReadBytes(len);
                CFXEnvelope result = FromBytes(data);
                result.QueueFilePosition = filePosition;
                result.Transmitted = transmitted;
                return result;
            }
            catch (Exception ex)
            {
                AppLog.Error(ex);
            }

            return null;
        }

        internal void WriteRecord(BinaryWriter writer)
        {
            QueueFilePosition = writer.BaseStream.Position;
            writer.Write(Transmitted);
            byte[] data = this.ToBytes();
            writer.Write((Int32)data.Length);
            writer.Write(this.ToBytes());
        }

        internal void SetRecordTransmitted(BinaryWriter writer)
        {
            try
            {
                Transmitted = true;

                if (QueueFilePosition != -1)
                {
                    long curPos = writer.BaseStream.Position;
                    if (writer.BaseStream.Seek(QueueFilePosition, SeekOrigin.Begin) == QueueFilePosition)
                    {
                        writer.Write(Transmitted);
                        writer.BaseStream.Seek(curPos, SeekOrigin.Begin);
                    }

                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                AppLog.Error(e);
            }
        }

        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToJson());
        }

        public static CFXEnvelope FromBytes(byte[] data)
        {
            return CFXEnvelope.FromJson(Encoding.UTF8.GetString(data));
        }
    }
}


#pragma warning restore 1591
