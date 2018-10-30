using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// A specialized type of Stage that represents a thermal zone within a solder reflow oven.
    /// </summary>
    public class ReflowZone : Stage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReflowZone()
        {
        }

        /// <summary>
        /// The type/purpose of this zone.
        /// </summary>
        public ReflowZoneType ReflowZoneType
        {
            get;
            set;
        }
    }
}
