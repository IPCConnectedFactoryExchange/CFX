using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a head for an endpoint that is an SMT placement machine.
    /// </summary>
    public class SMTHeadInformation : HeadInformation
    {
        /// <summary>
        /// An enumeration indicating the purpose of this particular head
        /// </summary>
        public SMTHeadType SMTHeadType
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the number of nozzle locations
        /// </summary>
        public int NumberOfNozzleLocations
        {
            get;
            set;
        }

        /// <summary>
        /// The accuracy of this head, expressed in mm. For example, a head that can accurately
        /// place components to 1 micron would have accuracy of 0.001 mm.
        /// </summary>
        public double PlacementAccuracy
        {
            get;
            set;
        }
    }
}
