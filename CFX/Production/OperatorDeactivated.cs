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
    ///     "OperatorIdentifier": "de1f03c5-b432-4603-b0d8-39c97469fe86",
    ///     "ActorType": "Human",
    ///     "FullName": "Bill Smith",
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
        /// A structure which defines the Operator
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}
