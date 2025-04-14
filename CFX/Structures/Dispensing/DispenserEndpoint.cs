using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// Describes the details of a particular CFX endpoint involved in the application of material (dispensing),  
    /// such glue dispensing and solder jetting.  This is a dynamic structure.
    /// </summary>
    public class DispenserEndpoint : Endpoint
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public DispenserEndpoint()
        {
            Lanes = new List<DispenserLaneInformation>();
            Heads = new List<DispenserHeadInformation>();
        }

        /// <summary>
        /// Information about the production lanes of this dispenser machine.
        /// </summary>
        public List<DispenserLaneInformation> Lanes
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the heads of this dispenser machine.
        /// </summary>
        public List<DispenserHeadInformation> Heads
        {
            get;
            set;
        }
    }
}
