using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Endpoint state model
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceState
    {
        /// <summary>
        /// Endpoint is Off (Shutdown)
        /// </summary>
        Off,
        /// <summary>
        /// Endpoint is on but not engaged in any activity
        /// </summary>
        On,
        /// <summary>
        /// Endpoint is being set up for production
        /// </summary>
        Setup,
        /// <summary>
        /// Endpoint is down (scheduled / planned)
        /// </summary>
        ScheduledDowntime,
        /// <summary>
        /// Endpoint is undergoing maintenance
        /// </summary>
        ScheduledMaintenance,
        /// <summary>
        /// Endpoint is being used by engineering for experimental / development purposes
        /// </summary>
        Engineering,
        /// <summary>
        /// Endpoint is performing non-value added work during production
        /// </summary>
        ReadyProcessingActive,
        /// <summary>
        /// Endpoint is performing value added work during production
        /// </summary>
        ReadyProcessingExecuting,
        /// <summary>
        /// Endpoint is ready for production, but not performing any work
        /// </summary>
        Idle,
        /// <summary>
        /// Endpoint is ready for production, but cannot perform work because downstream process is blocking
        /// </summary>
        IdleBlocked,
        /// <summary>
        /// Endpoint is ready for production, but cannot perform work because no units are available form upstream process
        /// </summary>
        IdleStarved,
        /// <summary>
        /// Endpoint is ready for production, but intentionally skipped or left unutilized because it is unecessary
        /// </summary>
        Bypass,
        /// <summary>
        /// Endpoint is down (unscheduled / unplanned)
        /// </summary>
        UnplannedDowntime,
        /// <summary>
        /// Endpoint is idle and in low power mode
        /// </summary>
        Sleep
    }
}
