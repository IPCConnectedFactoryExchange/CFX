using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when a fault is cleared as described in a FaultOccurred message  
    /// <code language="none">
    /// {
    ///   "FaultOccurrenceId": "22ac3c8a-9e6d-42f8-85b2-f51bf2224ecc",
    ///   "Operator": {
    ///     "OperatorIdentifier": "BADGE4486",
    ///     "ActorType": "Human",
    ///     "LastName": "Doe",
    ///     "FirstName": "John",
    ///     "LoginName": "john.doe@domain1.com"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class FaultCleared : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FaultCleared()
        {
        }

        /// <summary>
        /// A unique identifier of the instance of the related fault.  Corresponds with the
        /// FaultOccurrenceId property of the corresponding FaultOccurred message
        /// </summary>
        public Guid FaultOccurrenceId
        {
            get;
            set;
        }

        /// <summary>
        /// The operator or entity who has cleared the fault (if known, otherwise null) (optional)
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}
