using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance.THTInsertion
{
    public class ComponentsInserted : CFXMessage
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

        public int TotalComponentsInserted { get; set; }

        public int TotalComponentsNotInserted { get; set; }
    }
}

