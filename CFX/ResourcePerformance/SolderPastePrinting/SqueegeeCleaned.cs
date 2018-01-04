using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class SqueegeeCleaned : CFXMessage
    {
        public SMTSqueegee Squeegee
        {
            get;
            set;
        }

        public TimeSpan TimeSinceLastClean
        {
            get;
            set;
        }

        public int CyclesSinceLastClean
        {
            get;
            set;
        }

        public int SqueegeeCleanCycles
        {
            get;
            set;
        }

        public TimeSpan SqueegeeCleanTime
        {
            get;
            set;
        }
    }
}
