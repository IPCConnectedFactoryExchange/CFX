using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Describes a lane for an endpoint that is an SMT placement machine.
    /// </summary>
    public class SMTLaneInformation
    {
        /// <summary>
        /// The name of this lane.  Corresponds with Lane property in production messages.
        /// </summary>
        public string LaneName
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum and minimum dimensions that a PCB panel or fixture must conform
        /// to in order to be processed by this lane.
        /// </summary>
        public DimensionalConstraints SupportedPCBDimensions
        {
            get;
            set;
        }
    }
}
