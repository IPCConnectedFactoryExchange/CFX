using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceState
    {
        Off,
        On,
        Setup,
        ScheduledDowntime,
        ScheduledMaintenance,
        Engineering,
        ReadyProcessingActive,
        ReadyProcessingExecuting,
        Idle,
        IdleBlocked,
        IdleStarved,
        Bypass,
        UnplannedDowntime,
        Sleep,
        Offline
    }
}
