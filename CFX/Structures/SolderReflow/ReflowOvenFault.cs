using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// A specialized type of fault that is produced by an endpoint that is a reflow oven.
    /// </summary>
    public class ReflowOvenFault : Fault
    {
        /// <summary>
        /// The type of this reflow oven fault.
        /// </summary>
        public ReflowOvenFaultType ReflowOvenFaultType
        {
            get;
            set;
        }
    }
}
