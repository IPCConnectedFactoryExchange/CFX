using CFX.Structures.SMTPlacement;
using System;

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

        /// <summary>
        /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
        /// The specific time when this material / part was picked or at least tried to be picked (optional, when known)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public DateTime? PickingTime
        {
            get;
            set;
        }

        /// <summary>
        /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
        /// The picking sequence within the corresponding picking cycle for this material / part. For example, if the material has been picked (or tried to be picked) as the first component of the picking cycle, the value will be 1.  (optional, when known)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public int? PickingSequence
        {
            get;
            set;
        }
    }
}
