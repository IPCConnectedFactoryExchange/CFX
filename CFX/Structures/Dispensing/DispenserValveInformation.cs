using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Dispensing
{
    /// <summary>
    /// Describes a valve for an endpoint that is a dispensing machine.
    /// </summary>
    public class DispenserValveInformation
      {
        /// <summary>
        /// A unique identifier describing this particular valve instance; Typically, this identifier is barcoded or otherwise labeled on the valve
        /// </summary>
        public string ValveId
        {
            get;
            set;
        }

        /// <summary>
        /// A friendly name for this valve
        /// </summary>
        public string ValveName
        {
          get;
          set;
        }

        /// <summary>
        /// Sequence of this valve on the head
        /// </summary>
        public Int32 ValveSequence
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the dispensing valve
        /// </summary>
        public DispenserValveType DispenserValveType
        {
            get;
            set;
        }
    }
}
