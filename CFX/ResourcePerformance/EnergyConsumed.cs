using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint on a sampled interval of between 1 minute and 1 hour
    /// to indicate the energy usage and power consumption.
    /// <code language="none">
    /// {
    ///   "StartTime": "2018-04-05T09:33:06.1358356-04:00",
    ///   "EndTime": "2018-04-05T09:38:06.1358356-04:00",
    ///   "EnergyUsed": 0.012,
    ///   "PeakPower": 125.6,
    ///   "MinimumPower": 120.3,
    ///   "MeanPower": 124.6
    /// }
    /// </code>
    /// </summary>
    public class EnergyConsumed : CFXMessage
    {
        /// <summary>
        /// The start time of the sample period
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// The end time of the sample period
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// The total amount of energy consumed during the sample period
        /// (in kilowatt-hours)
        /// </summary>
        public double EnergyUsed
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum amount of power recorded during the sample period
        /// (in watts)
        /// </summary>
        public double PeakPower
        {
            get;
            set;
        }

        /// <summary>
        /// The lowest amount of power recorded during the sample period
        /// (in watts)
        /// </summary>
        public double MinimumPower
        {
            get;
            set;
        }

        /// <summary>
        /// The average amount of power consumed during the sample period
        /// (in watts)
        /// </summary>
        public double MeanPower
        {
            get;
            set;
        }
    }
}
