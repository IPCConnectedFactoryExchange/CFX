using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class FaultOccurred
    {
        public SMTPastePrintingFaultType PastePrintingFaultType
        {
            get;
            set;
        }
    }
}
