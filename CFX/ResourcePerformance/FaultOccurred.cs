using System;
using System.Collections.Generic;
using System.Text;

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
