using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapePitch
    {
        NotSpecified,
        Adjustable,
        Pitch2mm,
        Pitch4mm,
        Pitch8mm,
        Pitch12mm,
        Pitch16mm,
        Pitch24mm,
        Pitch32mm,
        Pitch36mm,
    }
}
