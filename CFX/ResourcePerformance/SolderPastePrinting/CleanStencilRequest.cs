using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class CleanStencilRequest : CFXMessage
    {
        public SMTCleanType CleanTypeRequested
        {
            get;
            set;
        }
    }
}
