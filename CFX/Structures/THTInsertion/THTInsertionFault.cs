using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.THTInsertion
{
    public class THTInsertionFault : Fault
    {
        public THTInsertionFault()
        {
            InsertionFaultType = THTInsertionFaultType.InsertionError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
        }

        /// <summary>
        /// The type of THT fault
        /// </summary>
        public THTInsertionFaultType InsertionFaultType
        {
            get;
            set;
        }
        
        /// <summary>
        /// An integer representing the step in the program/recipe that was
        /// being executed when the fault occurred.
        /// </summary>
        public int ProgramStep
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the specific component the inserter was trying to insert
        /// when the fault occurred.
        /// </summary>
        public ComponentDesignator Designator
        {
            get;
            set;
        }

        public MaterialLocation MaterialLocation
        {
            get;
            set;
        }
    }
}
