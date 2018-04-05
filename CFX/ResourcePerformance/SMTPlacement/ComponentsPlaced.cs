using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SMTPlacement
{
    /// <summary>
    /// Sent periodically by an SMT placement machine to indicate the number of placements which were
    /// successfully or unsuccessfully completed during the sample time window.
    /// This sample time window shall not exceed 10 minutes.
    /// <code language="none">
    /// {
    ///   "StartTime": "2018-04-05T09:28:06.161835-04:00",
    ///   "EndTime": "2018-04-05T09:38:06.161835-04:00",
    ///   "TotalComponentsPlaced": 875,
    ///   "TotalComponentsNotPlaced": 45
    /// }
    /// </code>
    /// </summary>
    public class ComponentsPlaced : CFXMessage
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
        /// The total number of components that were successfully placed during the sample period
        /// </summary>
        public int TotalComponentsPlaced { get; set; }

        /// <summary>
        /// The total number of components that were not successfully placed during the sample period
        /// </summary>
        public int TotalComponentsNotPlaced { get; set; }
    }
}

