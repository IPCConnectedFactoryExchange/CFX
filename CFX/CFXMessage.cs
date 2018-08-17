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
        public string ToJson(bool formatted = false)
        {
            return CFXJsonSerializer.SerializeObject(this, formatted);
        }

        public static CFXMessage FromTypeName(string messageType)
        {
            Type type = Type.GetType(messageType);
            return Activator.CreateInstance(type) as CFXMessage;
        }

        public static T FromJson<T>(string jsonData) where T : CFXMessage
        {
            return CFXJsonSerializer.DeserializeObject<T>(jsonData);
        }

        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(CFXJsonSerializer.SerializeObject(this));
        }

        public static T FromBytes<T>(byte [] data) where T : CFXMessage
        {
            return CFXJsonSerializer.DeserializeObject<T>(Encoding.UTF8.GetString(data));
        }
    }
}
