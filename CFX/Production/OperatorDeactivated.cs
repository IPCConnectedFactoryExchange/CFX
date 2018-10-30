using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Indicates that an activated operator is no longer active or responsible at a process endpoint
    /// <code language="none">
    /// {
    ///   "Operator": {
    ///     "OperatorIdentifier": "ea9da45d-9b1f-4e6a-974f-df06aeede42f",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class OperatorDeactivated : CFXMessage
    {
        /// <summary>
        /// A structure which defines the Operator (optional)
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}
