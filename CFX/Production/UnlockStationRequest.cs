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
    /// Request that a process endpoint resume production, following a previous lock. The response indicates that the lock has been removed.
    /// <code language="none">
    /// {
    ///   "Lane": null,
    ///   "Stage": null,
    ///   "Requestor": {
    ///     "OperatorIdentifier": "71926954-6b23-4f83-a5b4-ed7ef8cc226d",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Bill",
    ///     "LoginName": "bill.smith@domain1.com"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class UnlockStationRequest : CFXMessage
    {
        /// <summary>
        /// An optional production lane.  When specified, only that production lane shall be unlocked.
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional stage designating the particular production stage to be unlocked
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the operator who is requesting that the stage be unlocked. (optional)
        /// </summary>
        public Operator Requestor
        {
            get;
            set;
        }
    }
}
