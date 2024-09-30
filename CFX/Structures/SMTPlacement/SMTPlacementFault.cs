using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// A specific type of fault that is produced by endpoints responsible
    /// for the picking and placing of SMD components
    /// </summary>
    public class SMTPlacementFault : Fault
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SMTPlacementFault()
        {
            PlacementFaultType = SMTPlacementFaultType.PickupError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
            HeadAndNozzle = new SMTHeadAndNozzle();
        }

        /// <summary>
        /// The specific type of SMT placement fault 
        /// </summary>
        public SMTPlacementFaultType PlacementFaultType
        {
            get;
            set;
        }

        /// <summary>
        /// An integer representing the step in the program/recipe that was
        /// being executed when the fault occurred (where applicable)
        /// </summary>
        public int ProgramStep
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the specific component the placer was trying to place
        /// when the fault occurred (where applicable)
        /// </summary>
        public ComponentDesignator Designator
        {
            get;
            set;
        }

        /// <summary>
        /// The material carrier location related to this fault (where applicable)
        /// </summary>
        public MaterialLocation MaterialLocation
        {
            get;
            set;
        }

        /// <summary>
        /// The placement head and nozzle related to this fault (where applicable)
        /// </summary>
        public SMTHeadAndNozzle HeadAndNozzle
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// If the material package is used as an alternate part, this parameter indicates the original part number.
        /// For example, if A0805-001 was supposed to be used but A0805-002 was used instead (because A0805-001 was missing for example),
        /// the internal part number of the material package will be A0805-002, and the referecne part number will be A0805-001.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public string ReferencePartNumber
        {
            get;
            set;
        }
    }
}
