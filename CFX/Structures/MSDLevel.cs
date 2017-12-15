using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MSDLevel
    {
        Unspecified,
        MSL1,
        MSL2,
        MSL2A,
        MSL3,
        MSL4,
        MSL5,
        MSL5A,
        MSL6
    }
}
