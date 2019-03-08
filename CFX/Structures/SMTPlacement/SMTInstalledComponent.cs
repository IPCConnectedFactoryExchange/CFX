using CFX.Structures.SMTPlacement;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a particular InstalledComponent for SMT Placement
    /// </summary>
    public class SMTInstalledComponent : InstalledComponent
    {
        /// <summary>
        /// The particular Head / Nozzle with which the component has been installed
        /// </summary>
        public SMTHeadAndNozzle HeadAndNozzle
        {
            get;
            set;
        }
    }
}
