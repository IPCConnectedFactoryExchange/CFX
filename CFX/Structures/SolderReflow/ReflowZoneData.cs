using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// Provides information about the conditions of a particular zone of a reflow oven at a given point in time.
    /// </summary>
    public class ReflowZoneData
    {
        /// <summary>
        /// Zone / Stage to which this reflow data is related.
        /// </summary>
        public ReflowZone Zone
        {
            get;
            set;
        }
        
        /// <summary>
        /// The set point (in degrees celcius) for this zone for the region
        /// above the PCB.
        /// </summary>
        public double TopTempSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The average actual temperature (in degrees celcius) that was measured and recorded
        /// for this zone for the region above the PCB at the time when the transaction 
        /// took place.
        /// </summary>
        public double TopActualTemp
        {
            get;
            set;
        }

        /// <summary>
        /// The average power (in watts) being consumed by the top heaters of this zone at the time 
        /// when the transaction took place.
        /// </summary>
        public double TopPower
        {
            get;
            set;
        }

        /// <summary>
        /// The set point (in degrees celcius) for this zone for the region
        /// below the PCB.
        /// </summary>
        public double BotTempSetpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The average actual temperature (in degrees celcius) that was measured and recorded
        /// for this zone for the region below the PCB at the time when the transaction 
        /// took place.
        /// </summary>
        public double BotActualTemp
        {
            get;
            set;
        }

        /// <summary>
        /// The average power (in watts) being consumed by the bottom heaters of this zone at the time 
        /// when the transaction took place.
        /// </summary>
        public double BotPower
        {
            get;
            set;
        }
    }
}
