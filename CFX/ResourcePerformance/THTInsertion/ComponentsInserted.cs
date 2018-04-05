using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.THTInsertion
{
    /// <summary>
    /// Sent periodically by an THT inserter to indicate the number of insertions which were
    /// successfully or unsuccessfully completed during the sample time window.
    /// This sample time window shall not exceed 10 minutes.
    /// </summary>
    public class ComponentsInserted : CFXMessage
    {
        /// <summary>
        /// The start of the sample period
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// The end of the sample period
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of components that were successfully inserted during the sample period
        /// </summary>
        public int TotalComponentsInserted { get; set; }

        /// <summary>
        /// The total number of components that were not successfully inserted during the sample period
        /// </summary>
        public int TotalComponentsNotInserted { get; set; }
    }
}

