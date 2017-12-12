using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceState
    {
        Unknown,
        Active_Starved,
        Active_Blocked,
        Active_Working,
        Inactive_MaterialExhausted,
        Inactive_Setup,
        Down_Planned,
        Down_Unplanned,
    }
}
