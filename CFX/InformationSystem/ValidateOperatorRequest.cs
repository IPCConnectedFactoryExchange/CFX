using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem
{
    /// <summary>
    /// Request that an operator take action now or be responsible for a process endpoint.
    /// The opposite endpoint can accept or reject this. Can be used if the MES has 
    /// advanced user management. Multiple operators must be requested separately. 
    /// <code language="none">
    /// {
    ///   "Operator": {
    ///     "OperatorIdentifier": "42b7a5cc-3bbd-4010-8a01-1c5851b9a2a3",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class ValidateOperatorRequest : CFXMessage
    {
        /// <summary>
        /// A structure which defines the Operator.
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}