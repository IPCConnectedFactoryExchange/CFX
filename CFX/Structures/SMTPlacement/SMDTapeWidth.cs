using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Width of Taped SMD's
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMDTapeWidth
    {
        /// <summary>
        /// 8mm Width
        /// </summary>
        Tape8mm,
        /// <summary>
        /// 12mm Width
        /// </summary>
        Tape12mm,
        /// <summary>
        /// 16mm Width
        /// </summary>
        Tape16mm,
        /// <summary>
        /// 24mm Width
        /// </summary>
        Tape24mm,
        /// <summary>
        /// 32mm Width
        /// </summary>
        Tape32mm,
        /// <summary>
        /// 44mm Width
        /// </summary>
        Tape44mm,
        /// <summary>
        /// 79mm Width
        /// </summary>
        Tape79mm,
        /// <summary>
        /// Some width other than those specified in this enumeration
        /// </summary>
        Other
    }
}
