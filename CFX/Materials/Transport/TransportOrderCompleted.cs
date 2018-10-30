using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// Sent when a transport order has arrived at its final destination.
    /// <code language="none">
    /// {
    ///   "TransportOrderId": "TR329483249830000",
    ///   "Comments": "Received at Line 1",
    ///   "AcceptedBy": {
    ///     "OperatorIdentifier": "BADGE4487",
    ///     "ActorType": "Human",
    ///     "LastName": "Dolittle",
    ///     "FirstName": "Mike",
    ///     "LoginName": "mike.dolittle@domain1.com"
    ///   },
    ///   "RelatedWorkOrderId": "WO2384702937403280032",
    ///   "FinalDestination": "LINE 1"
    /// }
    /// </code>
    /// </summary>
    public class TransportOrderCompleted : CFXMessage
    {
        /// <summary>
        /// The order number of the related transport order
        /// </summary>
        public string TransportOrderId
        {
            get;
            set;
        }

        /// <summary>
        /// Human readable comments related to this arrival event (when applicable)
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// The operator who accepted the delivery, and recorded the arrival (optional)
        /// </summary>
        public Operator AcceptedBy
        {
            get;
            set;
        }

        /// <summary>
        /// The related production work order number (where applicable)
        /// </summary>
        public string RelatedWorkOrderId
        {
            get;
            set;
        }

        /// <summary>
        /// The final destination where the transport order was delivered)
        /// </summary>
        public string FinalDestination
        {
            get;
            set;
        }
    }
}
