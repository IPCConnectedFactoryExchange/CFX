using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderPastePrinting
{
    public class SMTSolderPastePrintingFault : Fault
    {
        public SMTSolderPastePrintingFault()
        {
            PrintingFaultType = SMTSolderPastePrintingFaultType.SqueegeeError;
        }

        public SMTSolderPastePrintingFaultType PrintingFaultType
        {
            get;
            set;
        }
    }
}
