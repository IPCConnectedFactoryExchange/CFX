using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Requests all Sensors values related to a tool
    /// </summary>
    public class GetSensorsRequest
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingTool ToolIdentification;

         /// <summary>
        /// default constructor
        /// </summary>
        public GetSensorsRequest()
        {
            ToolIdentification = new IdentifySolderingTool();
        }
    }
}