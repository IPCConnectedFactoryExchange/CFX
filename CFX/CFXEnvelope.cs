using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;
using CFX.Utilities;

#pragma warning disable 1591

namespace CFX
{
    /// <summary>
    /// The <see cref="CFXEnvelope"/> class is the outer envelope or container in which all CFX messages are enclosed for transmission.
    /// Common properties, such as a globally unique identifier (ID) and the timestamp for the message (TimeStamp),
    /// are defined by this container class and are included with all CFX message transmissions.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CFXEnvelope
    {
        public CFXEnvelope()
        {
            UniqueID = Guid.NewGuid();
            Version = "1.0";
            TimeStamp = DateTime.Now;
        }

        public const string CFXVERSION = "1.0";
        
        public CFXEnvelope(Type messageType) : this()
        {
            MessageBody = Activator.CreateInstance(messageType);
        }

        public CFXEnvelope(CFXMessage message) : this()
        {
            MessageBody = message;
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
        [JsonProperty]
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

        public string ToJson()
        {
            return CFXJsonSerializer.SerializeObject(this);
        }

        public static CFXEnvelope FromCFXMessage(CFXMessage msg)
        {
            return new CFXEnvelope(msg);
        }

        public static CFXEnvelope FromJson(string jsonData)
        {
            CFXEnvelope env = CFXJsonSerializer.DeserializeObject<CFXEnvelope>(jsonData);
            Type tp = Type.GetType(env.MessageName);
            env.MessageBody = CFXJsonSerializer.DeserializeObject(env.MessageBody.ToString(), tp);
            return env;
        }

        public static List<CFXEnvelope> FromJsonList(string jsonData)
        {
            List<CFXEnvelope> list = CFXJsonSerializer.DeserializeObject<List<CFXEnvelope>>(jsonData);
            foreach (CFXEnvelope env in list)
            {
                Type tp = Type.GetType(env.MessageName);
                env.MessageBody = CFXJsonSerializer.DeserializeObject(env.MessageBody.ToString(), tp);
            }

            return list;
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
