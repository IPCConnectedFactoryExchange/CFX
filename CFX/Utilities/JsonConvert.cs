using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace CFX.Utilities
{
    public class JsonConvert
    {
        //public static string SerializeObject(object o)
        //{
        //    string result = null;
        //    using (MemoryStream stream1 = new MemoryStream())
        //    {
        //        DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
        //        //settings.EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.Never;
        //        settings.UseSimpleDictionaryFormat = true;
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(o.GetType(), settings);
        //        ser.WriteObject(stream1, o);
        //        result = Encoding.Default.GetString(stream1.ToArray());
        //    }

        //    return result;
        //}

        //public static T DeserializeObject<T>(string jsonData)
        //{
        //    object result = null;
        //    using (MemoryStream stream1 = new MemoryStream(Encoding.Default.GetBytes(jsonData)))
        //    {
        //        DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
        //        result = ser.ReadObject(stream1);
        //    }

        //    return (T)result;
        //}

        public static string SerializeObject(object o)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            settings.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            return Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented, settings);
        }

        public static T DeserializeObject<T>(string jsonData)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData, settings);
        }

        public static object DeserializeObject(string jsonData, Type type)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData, type, settings);
        }
    }
}
