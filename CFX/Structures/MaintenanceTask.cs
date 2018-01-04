using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class MaintenanceTask
    {
        public string Task
        {
            get;
            set;
        }

        public string TaskId
        {
            get;
            set;
        }

        public Operator Operator
        {
            get;
            set;
        }

        public double ManHoursConsumed
        {
            get;
            set;
        }
    }
}
