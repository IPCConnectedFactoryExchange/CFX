using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CFX.Utilities
{
    public class CFXJsonSerializer
    {
        public static string SerializeObject(object o)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            //settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            settings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
            return Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented, settings);
        }

        public static string SerializeObjectWithTypes(object o)
        {
            Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            settings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
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
