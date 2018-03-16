using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of Maintenance
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaintenanceType
    {
        /// <summary>
        /// Maintenance intended to prevent breakdowns that have not yet occurred
        /// </summary>
        Preventive,
        /// <summary>
        /// Inspection intended to prevent breakdowns that have not yet occurred
        /// </summary>
        Inspection,
        /// <summary>
        /// Repair of a breakdown that has occurred.
        /// </summary>
        Repair,
        /// <summary>
        /// Testing of repairs made
        /// </summary>
        Test
    }
}
