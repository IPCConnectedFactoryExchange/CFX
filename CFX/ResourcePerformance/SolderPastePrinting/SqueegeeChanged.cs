using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class SqueegeeChanged : CFXMessage
    {
        public SMTSqueegee OldSqueegee
        {
            get;
            set;
        }

        public SMTSqueegee NewSqueegee
        {
            get;
            set;
        }
    }
}
