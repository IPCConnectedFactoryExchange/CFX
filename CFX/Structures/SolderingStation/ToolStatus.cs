using CFX.Structures.SolderingStation.Identification;


namespace CFX.Structures.SolderingStation
{ 
    /// <summary>
    /// Describes cartridge general status
    /// </summary>
    public class ToolStatus
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public ToolStatus()
        {
            CartridgeStatus = Mode.stopped;
            ToolIdentify = new IdentifySolderingTool();
        }
        /// <summary>
        /// Functional realtime cartridge functional status
        /// </summary>
        public enum Mode
        {
             stopped, started, locked
        }
    /// <summary>
    /// complete path to cartridge
    /// </summary>
        public IdentifySolderingTool ToolIdentify;
        public Mode CartridgeStatus;

    }
}
