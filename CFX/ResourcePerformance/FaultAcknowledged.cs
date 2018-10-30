using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent when a fault has been acknowledged by the operator, but not yet corrected (cleared).
    /// A subsequent FaultCleared message will be sent once the operator addresses the issue.
    /// <code language="none">
    /// {
    ///   "Operator": {
    ///     "OperatorIdentifier": "BADGE4486",
    ///     "ActorType": "Human",
    ///     "LastName": "Doe",
    ///     "FirstName": "John",
    ///     "LoginName": "john.doe@domain1.com"
    ///   },
    ///   "FaultOccurrenceId": "5af7e56c-cfbf-4f1f-aa4c-79d94a7442bc"
    /// }
    /// </code>
    /// </summary>
    public class FaultAcknowledged : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FaultAcknowledged()
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
        /// The operator or entity who has acknowledged the fault (if known, otherwise null) (optional)
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }
    }
}
