using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    public class ReflowSetPoint
    {
        public ReflowSubZoneType SubZone
        {
            get;
            set;
        }

        public ReflowSetpointType SetpointType
        {
            get;
            set;
        }

        public double? Setpoint
        {
            get;
            set;
        }
    }
}
