using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class SMTPlacementFault : Fault
    {
        public SMTPlacementFault()
        {
            PlacementFaultType = SMTPlacementFaultType.PickupError;
            Designator = new ComponentDesignator();
            MaterialLocation = new MaterialLocation();
            Nozzle = new SMTNozzle();
        }

        public SMTPlacementFaultType PlacementFaultType
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

        public SMTNozzle Nozzle
        {
            get;
            set;
        }
    }
}
