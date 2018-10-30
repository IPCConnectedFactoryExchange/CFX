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
    /// An enumeration indicating an area within a reflow zone that is under thermal control.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReflowSubZoneType
    {
        /// <summary>
        /// Applies to the entire zone.
        /// </summary>
        WholeZone,
        /// <summary>
        /// Applies to the region of the zone above the printed circuit card.
        /// </summary>
        Top,
        /// <summary>
        /// Applies to the region of the zone below the printed circuit card.
        /// </summary>
        Bottom,
    }
}
