using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SMTPlacement
{
    public class FaultOccurred : CFXMessage
    {
        public FaultOccurred()
        {
            Fault = new SMTPlacementFault();
        }

        public SMTPlacementFault Fault
        {
            get;
            set;
        }
    }
}
