using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Indicates that an activated operator is no longer active or responsible at a process endpoint
    /// </summary>
    public class OperatorDeactivated : CFXMessage
    {
        /// <summary>
        /// A structure which defines the Operator
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}
