using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// A data structure describing the set point for a particular area within a zone of a solder reflow oven.
    /// </summary>
    public class ReflowSetPoint
    {
        /// <summary>
        /// The area within the zone to which the setpoint applies.
        /// </summary>
        public ReflowSubZoneType SubZone
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration describing the type of setpoint.
        /// </summary>
        public ReflowSetpointType SetpointType
        {
            get;
            set;
        }

        /// <summary>
        /// The nominal, target value of this setpoint.
        /// </summary>
        public double? Setpoint
        {
            get;
            set;
        }
    }
}
