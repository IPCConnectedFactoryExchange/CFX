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
        /// The zone is a Dispensing Nozzle.
        /// </summary>
        Dispensing,
        /// <summary>
        /// The zone is a Curtain Nozzle.
        /// </summary>
        Curtain,
        /// <summary>
        /// The zone is a Curtain Nozzle.
        /// </summary>
        Spray,
        /// <summary>
        /// The zone is a Curtain Nozzle.
        /// </summary>
        Doaser
    }
}
