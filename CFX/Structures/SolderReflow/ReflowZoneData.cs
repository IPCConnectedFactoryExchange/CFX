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
        /// Default Constructor
        /// </summary>
        public ReflowZoneData()
        {
            Readings = new List<ReflowReading>();
        }

        /// <summary>
        /// Zone / Stage to which this reflow data is related.
        /// </summary>
        public ReflowZone Zone
        {
            get;
            set;
        }

        /// <summary>
        /// A list of current setpoints associated with this zone.
        /// </summary>
        public List<ReflowSetPoint> Setpoints
        {
            get;
            set;
        }

        /// <summary>
        /// A list of readings / measurements that have been taken for this zone.
        /// </summary>
        public List<ReflowReading> Readings
        {
            get;
            set;
        }
    }
}
