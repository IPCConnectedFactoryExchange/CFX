using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    public class FaultCleared : CFXMessage
    {
        public FaultCleared()
        {
        }

        public Guid FaultOccurrenceId
        {
            get;
            set;
        }
    }
}
