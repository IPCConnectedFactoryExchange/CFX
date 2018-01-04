using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    public class FaultOccurred : CFXMessage
    {
        public FaultOccurred()
        {
            Fault = new Fault();
        }

        public Fault Fault
        {
            get;
            set;
        }
    }
}
