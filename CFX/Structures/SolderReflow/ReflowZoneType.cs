using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// An enumeration indicating the nature of a zone within a reflow oven
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReflowZoneType
    {
        /// <summary>
        /// This is a pre-heat zone.
        /// </summary>
        PreHeat,
        /// <summary>
        /// The zone is a thermal soak zone.
        /// </summary>
        Soak,
        /// <summary>
        /// This zone is intended to induce solder reflow.
        /// </summary>
        Reflow,
        /// <summary>
        /// This is a cooling zone.
        /// </summary>
        Cool
    }
}
