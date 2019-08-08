using CFX.Structures.SMTPlacement;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a particular NonInstalledComponent for SMT Placement
    /// </summary>
    public class SMTNonInstalledComponent : NonInstalledComponent
    {
        /// <summary>
        /// The particular Head / Nozzle with which the component has not been installed
        /// </summary>
        public SMTHeadAndNozzle HeadAndNozzle
        {
            get;
            set;
        }
    }
}
