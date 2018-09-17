using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// Provides information about the conditions within a reflow oven at a given point in time.
    /// </summary>
    public class ReflowProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReflowProcessData()
        {
            ZoneData = new List<ReflowZoneData>();
        }

        /// <summary>
        /// The speed (in cm / minute) of the conveyor
        /// </summary>
        public double ConveyorSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The convery speed setpoint (in cm / minute)
        /// </summary>
        public double ConveyorSpeedSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// Process data (temperatures, etc.) for each zone of the reflow oven at the 
        /// time when this transaction tool place.
        /// </summary>
        public List<ReflowZoneData> ZoneData
        {
            get;
            set;
        }
    }
}
