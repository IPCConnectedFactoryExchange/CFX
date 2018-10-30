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
    ///   "Lane": 1,
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   },
    ///   "Reason": "QualityIssue",
    ///   "Requestor": {
    ///     "OperatorIdentifier": "e4d92c77-6a19-4d1e-8c2a-b2b217f59a44",
    ///     "ActorType": "Human",
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
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional stage.  When specified, only that stage shall be locked.
        /// </summary>
        public Stage Stage
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
        /// Identifies the originator of the request. (optional)
        /// </summary>
        public Operator Requestor
        {
            get;
            set;
        }
    }
}
