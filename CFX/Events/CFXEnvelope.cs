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
            MessageID = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }

        public CFXEnvelope(Type messageType) : this()
        {
            MessageBody = Activator.CreateInstance(messageType);
        }


        /// <summary>
        /// An identifier (128-bit GUID) that uniquely identifies this particular message instance.
        /// </summary>
        [JsonProperty]
        public Guid MessageID
        {
            get;
            set;
        }

        private Guid requestId = Guid.Empty;

        /// <summary>
        /// For envelopes involved in asynchronous request/response transactions between endpoints,
        /// a unique identifier (128-bit GUID) that uniquely identifies the request/response transaction.
        /// The endpoint that initiates the "Request" generates this identifier, and endpoints that respond
        /// should include this identifier in their "Response".
        /// </summary>
        [JsonProperty]
        public string RequestID
        {
            get
            {
                if (requestId != Guid.Empty) return requestId.ToString();
                return "";
            }
            set
            {
                if (!Guid.TryParse(value, out requestId))
                {
                    requestId = Guid.Empty;
                }
            }
        }

        /// <summary>
        /// The name of the enclosed CFX message (the type of message)
        /// </summary>
        [JsonProperty]
        public string MessageName
        {
            get
            {
                if (MessageBody == null) return null;
                return MessageBody.GetType().Name;
            }
            private set
            {
            }
        }

        /// <summary>
        /// The version number of the enclosed CFX message.
        /// </summary>
        [JsonProperty]
        public string MessageVersion
        {
            get;
            set;
        }

        /// <summary>
        /// A text field representing the CFX Endpoint ID that published this message. 
        /// </summary>
        [JsonProperty]
        public string EndpointID
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time when the event associated with this message ocurred.
        /// </summary>
        [JsonProperty]
        public DateTime TimeStamp
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
                    MessageName = messageBody.GetType().Name;
                    MessageVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
