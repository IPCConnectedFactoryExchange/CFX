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
    /// Reason for a production lock condition
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LockReason
    {
        /// <summary>
        /// Production locked due to quality related issue
        /// </summary>
        QualityIssue,
        /// <summary>
        /// Production locked due to preventative maintenance
        /// </summary>
        PreventativeMaintenance,
        /// <summary>
        /// Production locked due to unscheduled maintenance
        /// </summary>
        UnscheduledMaintenance,
        /// <summary>
        /// Production locked for unspecified reason
        /// </summary>
        GeneralLock
    }
}
