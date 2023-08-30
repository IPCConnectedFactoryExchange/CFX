using CFX.Structures.PCBInspection;
using CFX.Structures.SMTPlacement;
using System;

namespace CFX.Structures.SMTPlacement
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

        /// <summary>
        /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
        /// The specific time when this material / part was picked (optional, when known)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public DateTime? PickingTime
        {
            get;
            set;
        }

        /// <summary>
        /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
        /// The specific time when this material / part was picked (optional, when known)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public int? PickingSequence
        {
            get;
            set;
        }

        /// <summary>
        /// <para> ** NOTE: ADDED in CFX 2.0 **</para>
        /// The installation sequence within the corresponding placement cycle for this material / part. For example, if the material has been placed as the first component of the placement cycle, the value will be 1 (optional, when known)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public int? InstallationSequence
        {
            get;
            set;
        }         
    }
}
