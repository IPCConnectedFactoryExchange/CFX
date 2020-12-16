using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Utilities;
using Newtonsoft.Json;

namespace CFX
{
    /// <summary>
    /// Abstract base class for all CFX Messages.  Contains no data members.  Provides for the
    /// serialization and deserialization of messages to and from JSON format.
    /// </summary>
    //[JsonObject(MemberSerialization.OptIn)]
    public abstract class CFXMessage
    {
        /// <summary>
        /// Converts this message to a JSON formatting string
        /// </summary>
        /// <param name="formatted">Whether or not to format the JSON for easy human interpretation.  Adds whitespace and carriage returns.</param>
        /// <returns>A JSON formatted string</returns>
        public string ToJson(bool formatted = false)
        {
            return CFXJsonSerializer.SerializeObject(this, formatted);
        }

        /// <summary>
        /// Creates a new instance of a CFX message of the type specified in string format
        /// </summary>
        /// <param name="messageType">A fully qualified message type name in string format</param>
        /// <returns>The newly created instance of a CFX message</returns>
        public static CFXMessage FromTypeName(string messageType)
        {
            Type type = Type.GetType(messageType);
            return Activator.CreateInstance(type) as CFXMessage;
        }

        /// <summary>
        /// Creates a new instance of a CFX message of the type specified, using the JSON data provided
        /// </summary>
        /// <typeparam name="T">The Type of message to create</typeparam>
        /// <param name="jsonData">A JSON representation of the message to create</param>
        /// <returns>The newly created instnace of a CFX message</returns>
        public static T FromJson<T>(string jsonData) where T : CFXMessage
        {
            return CFXJsonSerializer.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// Converts this message to a binary representation in UTF8 format
        /// </summary>
        /// <returns>An array of butes that represent the message in UTF8 format</returns>
        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(CFXJsonSerializer.SerializeObject(this));
        }

        /// <summary>
        /// Creates a new instance of a CFX message given a Type and an array of bytes assumed to be in UTF8 encoding
        /// </summary>
        /// <typeparam name="T">The Type of the message</typeparam>
        /// <param name="data">An array of bytes representing the message in UTF8 format</param>
        /// <returns></returns>
        public static T FromBytes<T>(byte [] data) where T : CFXMessage
        {
            return CFXJsonSerializer.DeserializeObject<T>(Encoding.UTF8.GetString(data));
        }
    }
}
