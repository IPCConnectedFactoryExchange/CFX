using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Pitch of Tape Feeder
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapePitch
    {
        /// <summary>
        /// Adjustable Pitch Feeder
        /// </summary>
        Adjustable,
        /// <summary>
        /// 2mm Pitch
        /// </summary>
        Pitch2mm,
        /// <summary>
        /// 4mm Pitch
        /// </summary>
        Pitch4mm,
        /// <summary>
        /// 8mm Pitch
        /// </summary>
        Pitch8mm,
        /// <summary>
        /// 12mm Pitch
        /// </summary>
        Pitch12mm,
        /// <summary>
        /// 16mm Pitch
        /// </summary>
        Pitch16mm,
        /// <summary>
        /// 24mm Pitch
        /// </summary>
        Pitch24mm,
        /// <summary>
        /// 32mm Pitch
        /// </summary>
        Pitch32mm,
        /// <summary>
        /// 36mm Pitch
        /// </summary>
        Pitch36mm,
        /// <summary>
        /// Pitch other than those specified in this enumeration
        /// </summary>
        Other,
    }
}
