using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.THTInsertion
{
    public class FaultOccurred : CFXMessage
    {
        public FaultOccurred()
        {
            Fault = new THTInsertionFault();
        }

        public THTInsertionFault Fault { get; set; }
    }
}
