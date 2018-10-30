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
        /// A list of setpoints of varying types for each sub-area within this zone.
        /// </summary>
        public List<ReflowSetPoint> Setpoints
        {
            get;
            set;
        }
    }
}
