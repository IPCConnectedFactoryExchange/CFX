using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

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
