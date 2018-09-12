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
    ///     "OperatorIdentifier": "60d8e5c1-ca23-48c6-b56a-3572723176bd",
    ///     "ActorType": "Human",
    ///     "FullName": "Bill Smith",
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
        /// Information about the operator who is requesting that the stage be unlocked.
        /// </summary>
        public Operator Requestor
        {
            get;
            set;
        }
    }
}
