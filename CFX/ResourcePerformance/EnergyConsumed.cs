using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint on a sampled interval of between 1 minute and 1 hour
    /// to indicate the energy usage and power consumption.
    /// </summary>
    public class EnergyConsumed : CFXMessage
    {
        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }

        public double EnergyUsed
        {
            get;
            set;
        }

        public double PeakPower
        {
            get;
            set;
        }

        public double MinimumPower
        {
            get;
            set;
        }

        public double CurrentPower
        {
            get;
            set;
        }

        public double MeanPower
        {
            get;
            set;
        }
    }
}
