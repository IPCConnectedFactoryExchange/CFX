using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// A specific type of fault that is produced by endpoints responsible
    /// for the printing of solder paste on PCBs.
    /// </summary>
    public class SMTSolderPastePrintingFault : Fault
    {
        public SMTSolderPastePrintingFault()
        {
            PrintingFaultType = SMTSolderPastePrintingFaultType.SqueegeeError;
        }

        /// <summary>
        /// The specific type of printing fault
        /// </summary>
        public SMTSolderPastePrintingFaultType PrintingFaultType
        {
            get;
            set;
        }
    }
}
