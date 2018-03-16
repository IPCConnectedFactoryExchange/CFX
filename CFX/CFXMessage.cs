using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Utilities;
using Newtonsoft.Json;

namespace CFX
{
    //[JsonObject(MemberSerialization.OptIn)]
    public abstract class CFXMessage
    {
        public string ToJson()
        {
            return CFXJsonSerializer.SerializeObject(this);
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
