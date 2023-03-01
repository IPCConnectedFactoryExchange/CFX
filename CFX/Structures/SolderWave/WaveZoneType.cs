using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// An enumeration indicating the nature of a zone within a wave soldering zone <seealso cref="WaveZone"/>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaveZoneType
    {
        /// <summary>
        /// This is a fluxing zone.
        /// </summary>
        Flux,
        /// <summary>
        /// This is a zone with different kind of heaters.
        /// </summary>
        Preheat,
        /// <summary>
        /// This zone is intended to induce wave soldering.
        /// </summary>
        Solder,
        /// <summary>
        /// This is a cooling zone.
        /// </summary>
        Cool,
        /// <summary>
        /// This is a zone to specify a conveyor.
        /// </summary>
        Transport,
        /// <summary>
        /// This is the exhaust of the machine most whole zone.
        /// </summary>
        Exhaust
    }
}
