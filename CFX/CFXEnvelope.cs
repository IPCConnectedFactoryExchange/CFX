using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

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

        public CFXEnvelope(Type messageType) : this()
        {
            MessageBody = Activator.CreateInstance(messageType);
        }

        [JsonProperty]
        public string MessageName
        {
            get
            {
                if (MessageBody == null) return null;
                return MessageBody.GetType().FullName;
            }
            private set
            {
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
                if (messageBody != null)
                {
                    MessageName = messageBody.GetType().FullName;
                    //Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
            }
        }

        public T GetMessage<T>()
        {
            return (T)MessageBody;
        }
    }
}


#pragma warning restore 1591
