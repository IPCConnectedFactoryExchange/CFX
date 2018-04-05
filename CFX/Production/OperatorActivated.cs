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
    /// <code language="none">
    /// {
    ///   "Operator": {
    ///     "OperatorIdentifier": "8d24755a-36bf-4bb3-8736-71790f9a1f48",
    ///     "ActorType": "Human",
    ///     "FullName": "Bill Smith",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   }
    /// }
    /// </code>
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
