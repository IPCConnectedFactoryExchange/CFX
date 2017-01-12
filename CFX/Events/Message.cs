using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace CFX.Events
{
    /// <summary>
    /// The <see cref="Message"/> class is the outer envelope or container in which all CFX messages are enclosed for transmission.
    /// Common properties, such as a globally unique identifier (ID) and the timestamp for the message (TimeStamp),
    /// are defined by this container class and are included with all CFX message transmissions.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public Message()
        {
            ID = Guid.NewGuid();
        }


        /// <summary>
        /// A 128-bit number that uniquely identifies this particular message instance.
        /// </summary>
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the enclosed CFX message (in text format)
        /// </summary>
        public string MessageName
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time when this message was generated.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// The message payload (The CFX message content).
        /// </summary>
        public object MessageBody
        {
            get;
            set;
        }
    }
}

#pragma warning restore 1591
