using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class THTInsertionFault : Fault
    {
        public THTInsertionFault()
        {
            InsertionFaultType = THTInsertionFaultType.InsertionError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
        }

        public THTInsertionFaultType InsertionFaultType
        {
            get;
            set;
        }

        public int ProgramStep
        {
            get;
            set;
        }

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
