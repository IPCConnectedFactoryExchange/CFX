using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when a fault is cleared as described in a FaultOccurred message  
    /// <code language="none">
    /// {
    ///   "FaultOccurrenceId": "731ce619-7e80-4bf0-bb82-2985a9fa7368"
    /// }
    /// </code>

    /// </summary>
    public class FaultCleared : CFXMessage
    {
        public FaultCleared()
        {
        }

        /// <summary>
        /// A unique identifier of the instance of the related fault.  Corresponds with the
        /// FaultOccurrenceId property of the corresponding FaultOccurred message
        /// </summary>
        public Guid FaultOccurrenceId
        {
            get;
            set;
        }
    }
}
