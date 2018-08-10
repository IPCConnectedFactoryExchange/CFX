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
    public class SMTHeadInformation
    {
        /// <summary>
        /// The name or identifier of the SMT head
        /// </summary>
        public string HeadId
        {
            get;
            set;
        }

        /// <summary>
        /// The accuracy of this head, expressed in mm.  For example, a head that can accurately
        /// place components to 1 micron would have accuracy of 0.001 mm.
        /// </summary>
        public double PlacementAccuracy
        {
            get;
            set;
        }
    }
}
