using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.SMTPlacement
{
    public class ComponentsPlaced : CFXMessage
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

        public int TotalComponentsPlaced { get; set; }

        public int TotalComponentsNotPlaced { get; set; }
    }
}

