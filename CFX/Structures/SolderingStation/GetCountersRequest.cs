using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Requests counters (global or partial) related to named cartridge
    /// </summary>
    public class GetCountersRequest
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingTool ToolIdentification;
        
        /// <summary>
        /// Asking for
        /// </summary>
        public CountersType Type;

        /// <summary>
        /// default constructor
        /// </summary>
        public GetCountersRequest()
        {
            Type = CountersType.GLOBAL;
            ToolIdentification = new IdentifySolderingTool();
        }
    }
}
