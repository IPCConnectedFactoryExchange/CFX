using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Indicates that an operator is now active at or responsible for a process endpoint. 
    /// Having multiple operators (each needs to be activated and deactivated separately) or 
    /// an absence of an operator is possible. 
    /// </summary>
    public class OperatorActivated : CFXMessage
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
