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
        public SMTPlacementFault()
        {
            PlacementFaultType = SMTPlacementFaultType.PickupError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
            Nozzle = new SMTHead();
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
        /// The placement nozzle related to this fault (where applicable)
        /// </summary>
        public SMTHead Nozzle
        {
            get;
            set;
        }
    }
}
