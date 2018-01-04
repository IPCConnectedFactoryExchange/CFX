using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapeWidth
    {
        Tape8mm,
        Tape12mm,
        Tape16mm,
        Tape24mm,
        Tape32mm,
        Tape44mm,
        Tape79mm
    }
}
