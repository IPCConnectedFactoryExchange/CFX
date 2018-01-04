using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
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
