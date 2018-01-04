using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class StencilCleaned : CFXMessage
    {
        public SMTStencil Stencil
        {
            get;
            set;
        }

        public SMTStencilCleanMode StencilCleanMode
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

        public int StencilCleanCycles
        {
            get;
            set;
        }

        public TimeSpan StencilCleanTime
        {
            get;
            set;
        }
    }
}
