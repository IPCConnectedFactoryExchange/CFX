using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.PressInsertion
{
    /// <summary>
    /// Sent periodically by a Press Fit machine to indicate the number of presses which were
    /// successfully or unsuccessfully completed during the sample time window.
    /// <code language="none">
    /// {
    ///   "StartTime": "2018-04-06T08:06:46.4471059-04:00",
    ///   "EndTime": "2018-04-06T08:16:46.4471059-04:00",
    ///   "TotalComponentsPressed": 10,
    ///   "TotalComponentsNotPressed": 2
    /// }
    /// </code>
    /// </summary>
    public class ComponentsPressed : CFXMessage
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
        /// The total number of components that were successfully pressed during the sample period
        /// </summary>
        public int TotalComponentsPressed { get; set; }

        /// <summary>
        /// The total number of components that were not successfully pressed during the sample period
        /// </summary>
        public int TotalComponentsNotPressed { get; set; }
    }
}
