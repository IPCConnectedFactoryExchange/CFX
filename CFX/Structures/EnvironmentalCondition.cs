using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes an environmental condition that was in place when an action was performed.
    /// </summary>
    abstract public class EnvironmentalCondition
    {
        /// <summary>
        /// The start time for the sample period
        /// </summary>
        public DateTime? StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// The end time for the sample period
        /// </summary>
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// The average value during the sample period
        /// </summary>
        public double MeanValue
        {
            get;
            set;
        }

        /// <summary>
        /// The median value during the sample period
        /// </summary>
        public double MedianValue
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum value during the sample period
        /// </summary>
        public double MaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum value during the sample period
        /// </summary>
        public double MinValue
        {
            get;
            set;
        }
    }
}
