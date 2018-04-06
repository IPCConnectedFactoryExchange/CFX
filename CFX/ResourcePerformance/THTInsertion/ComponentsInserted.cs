using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.THTInsertion
{
    /// <summary>
    /// Sent periodically by an THT inserter to indicate the number of insertions which were
    /// successfully or unsuccessfully completed during the sample time window.
    /// This sample time window shall not exceed 10 minutes.
    /// <code language="none">
    /// {
    ///   "StartTime": "2018-04-06T08:06:46.4471059-04:00",
    ///   "EndTime": "2018-04-06T08:16:46.4471059-04:00",
    ///   "TotalComponentsInserted": 875,
    ///   "TotalComponentsNotInserted": 45
    /// }
    /// </code>
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

