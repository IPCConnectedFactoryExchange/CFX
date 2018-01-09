using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SMTPlacement
{
    public class SMTPastePrintingFault : Fault
    {
        public SMTPastePrintingFaultType PastePrintingFaultType
        {
            get;
            set;
        }
    }
}
