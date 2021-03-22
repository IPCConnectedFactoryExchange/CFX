using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// A specialized type of Stage that represents a Nozzle within a Coating Machine.
    /// </summary>
    public class CoatingNozzle : Stage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CoatingNozzle()
        {
        }

        /// <summary>
        /// The type/purpose of this Nozzle.
        /// </summary>
        public CoatingNozzleType CoatingNozzleType
        {
            get;
            set;
        }
    }
}
