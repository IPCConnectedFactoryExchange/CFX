using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// Dynamic Parameter structure containing the configurable parameters of a solder reflow oven.
    /// </summary>
    public class ReflowOvenParameter : Parameter
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReflowOvenParameter()
        {
            ZoneParameters = new List<ReflowZoneParameter>();
        }

        /// <summary>
        /// The desired conveyor speed, expressed in centimeters per minute (cm / min)
        /// </summary>
        public double ConveyorSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The width of the conveyor, expressed in centimeters (cm)
        /// </summary>
        public double ConveyorWidth
        {
            get;
            set;
        }

        public double VacuumLevel
        {
            get;
            set;
        }

        public TimeSpan VacuumLevelHoldTime
        {
            get;
            set;
        }

        public double ClosedLoopO2
        {
            get;
            set;
        }

        public double ConvectionRate
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the structures defining the parameters for each zone.
        /// </summary>
        public List<ReflowZoneParameter> ZoneParameters
        {
            get;
            set;
        }
    }
}
