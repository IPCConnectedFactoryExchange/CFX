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
        public static string SerializeObject(object o, bool formatted = false)
        {
            Newtonsoft.Json.Formatting format = formatted ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            if (JsonSettings == null) JsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            JsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            JsonSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
            return Newtonsoft.Json.JsonConvert.SerializeObject(o, format, JsonSettings);
        }

        public static string SerializeObjectWithTypes(object o, bool formatted = false)
        {
            Newtonsoft.Json.Formatting format = formatted ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            if (JsonSettings == null) JsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            JsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            JsonSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
            return Newtonsoft.Json.JsonConvert.SerializeObject(o, format, JsonSettings);
        }

        public static T DeserializeObject<T>(string jsonData)
        {
            if (JsonSettings == null) JsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            JsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData, JsonSettings);
        }

        public static object DeserializeObject(string jsonData, Type type)
        {
            if (JsonSettings == null) JsonSettings = new Newtonsoft.Json.JsonSerializerSettings();
            JsonSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData, type, JsonSettings);
        }

        public static Newtonsoft.Json.JsonSerializerSettings JsonSettings
        {
            get;
            set;
        }
    }
}
