using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when a fault is cleared as described in a FaultOccurred message  
    /// </summary>
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
