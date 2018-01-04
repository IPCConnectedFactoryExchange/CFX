using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    public class CleanSqueegeeResponse : CFXMessage
    {
        public CleanSqueegeeResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            set;
        }
    }
}
