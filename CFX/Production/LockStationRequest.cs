using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Request that the endpoint cease active operation (locked) as soon as practically possible
    /// at a process endpoint.  A specific production lane or stage may be optionally specified.
    /// Includes a reason, and applies to all operations. The response indicates that the process
    /// has stopped.
    /// <code language="none">
    /// {
    ///   "Lane": "1",
    ///   "Stage": "5",
    ///   "Reason": "QualityIssue",
    ///   "Requestor": {
    ///     "OperatorIdentifier": "bdcb4098-4645-4342-b85d-65a64c52393e",
    ///     "ActorType": "Human",
    ///     "FullName": "Bill Smith",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class LockStationRequest : CFXMessage
    {
        /// <summary>
        /// An optional production lane.  When specified, only that production lane shall be locked.
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional stage.  When specified, only that stage shall be locked.
        /// </summary>
        public string Stage
        {
            get;
            set;
        }

        /// <summary>
        /// Reason for the request to lock the station.
        /// </summary>
        public LockReason Reason
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the originator of the request.
        /// </summary>
        public Operator Requestor
        {
            get;
            set;
        }
    }
}
