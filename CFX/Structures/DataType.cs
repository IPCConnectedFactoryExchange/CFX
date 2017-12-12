using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataType
    {
        String,
        StringList,
        Numeric,
        Integer,
        Boolean,
        Enumeration,
        Binary,
        Guid
    }
}
