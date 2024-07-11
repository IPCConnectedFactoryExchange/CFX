using CFX.Structures.SolderingStation.Identification;
using System.Collections.Generic;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Cartridge partial counters Cartridge identification and Dictionary of station specific counters
    /// for example: PlugTime, WorkTime, WorkCycles, Idle, HibernationMinutes, HibernationCycles,SleepMinutes SleepCycles,
    /// IdleTime, DesoldCycles, DeliveredTinDecimeters, ...
    /// </summary>
    public class PartialCounters
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public PartialCounters()
        {
            ToolIdentification = new IdentifySolderingTool();
            Counters = new Dictionary<string, int>();
        }

        /// <summary>
        /// Cartridge path
        /// </summary>
        public IdentifySolderingTool ToolIdentification;

        /// <summary>
        /// Key, value partial counters
        /// </summary>
        public Dictionary<string, int> Counters;
    }
}
