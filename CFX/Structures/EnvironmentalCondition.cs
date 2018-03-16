using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    abstract public class EnvironmentalCondition
    {
        public DateTime? StartTime
        {
            get;
            set;
        }

        public DateTime? EndTime
        {
            get;
            set;
        }

        public double MeanValue
        {
            get;
            set;
        }

        public double MedianValue
        {
            get;
            set;
        }

        public double MaxValue
        {
            get;
            set;
        }

        public double MinValue
        {
            get;
            set;
        }
    }
}
