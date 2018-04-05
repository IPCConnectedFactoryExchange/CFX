using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.THTInsertion
{
    /// <summary>
    /// A specific type of fault that is produced by endpoints responsible
    /// for the insertion of through-hole electronic components (THT insertion)
    /// </summary>
    public class THTInsertionFault : Fault
    {
        public THTInsertionFault()
        {
            InsertionFaultType = THTInsertionFaultType.InsertionError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
        }

        /// <summary>
        /// The specific type of THT fault
        /// </summary>
        public THTInsertionFaultType InsertionFaultType
        {
            get;
            set;
        }

        /// <summary>
        /// An integer representing the step in the program/recipe that was
        /// being executed when the fault occurred  (where applicable)
        /// </summary>
        public int ProgramStep
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the specific component the inserter was trying to insert
        /// when the fault occurred  (where applicable)
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
    }
}
