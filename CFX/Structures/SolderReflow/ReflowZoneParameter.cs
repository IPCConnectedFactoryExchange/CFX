using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// Structure defining the parameters for a particular zone within a solder reflow oven.
    /// </summary>
    public class ReflowZoneParameter
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReflowZoneParameter()
        {
            Zone = new ReflowZone();
        }

        /// <summary>
        /// The related Zone (Stage)
        /// </summary>
        public ReflowZone Zone
        {
            get;
            set;
        }

        /// <summary>
        /// The temperature setpoint for the area above the PCB, expressed in degrees celcius (C).
        /// </summary>
        public double TopTempSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The temperature setpoint for the area below the PCB, expressed in degrees celcius (C).
        /// </summary>
        public double BotTempSetpoint
        {
            get;
            set;
        }
    }
}
