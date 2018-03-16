using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Tape type for Package of Taped SMD's
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapeType
    {
        /// <summary>
        /// Embossed Tape
        /// </summary>
        Embossed,
        /// <summary>
        /// Punched Paper Tape
        /// </summary>
        PunchedPaper,
    }
}
