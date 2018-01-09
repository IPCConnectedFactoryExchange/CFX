using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapeType
    {
        Embossed,
        PunchedPaper,
    }
}
