using CFX.Structures.SolderingStation.Identification;


namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Describes Soldering Station Cartridge working status
    /// </summary>
    public class ToolWorkingStatus
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public ToolWorkingStatus()
        {
            WorkingStatus = Mode.NoTool;
            ToolIdentify = new IdentifySolderingTool();
        }
        /// <summary>
        /// Functional realtime cartridge functional status
        /// </summary>
        public enum Mode
        {
            /// <summary>
            /// Cartridge not found
            /// </summary>
            NoTool,
            /// <summary>
            /// Working normal status , cartridge detected
            /// </summary>
            Work,
            /// <summary>
            /// once reachead Sleep mode , station stops cartridge heating to preset temperature
            /// </summary>
            Sleep,
            /// <summary>
            /// once reached Hibernation mode , station stops cartridge heating completely 
            /// </summary>
            Hibernation
        }
        /// <summary>
        /// complete path to cartridge
        /// </summary>
        public IdentifySolderingTool ToolIdentify;
        /// <summary>
        /// Cartridge related heating mode
        /// </summary>
        public Mode WorkingStatus;

    }
}
