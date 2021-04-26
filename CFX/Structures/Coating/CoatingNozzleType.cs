using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// An enumeration indicating the nature of a Nozzle within a Coating Machine
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CoatingNozzleType
    {
        /// <summary>
        /// This is a Jetter Nozzle.
        /// </summary>
        Jetter,
        /// <summary>
        /// The is a Dispensing Nozzle.
        /// </summary>
        Dispensing,
        /// <summary>
        /// The is a Type of Film Coater.
        /// </summary>
        Curtain,
        /// <summary>
        /// The is a Type of Film Coater.
        /// </summary>
        Spray,
        /// <summary>
        /// The is a Type of Film Coater.
        /// </summary>
        Doser
    }
}
