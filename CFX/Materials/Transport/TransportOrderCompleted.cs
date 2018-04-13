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
    ///   "TransportOrderNumber": "TR329483249830000",
    ///   "Comments": "Received at Line 1",
    ///   "AcceptedBy": {
    ///     "OperatorIdentifier": "b776aee6-0462-4a7d-9976-158a342f898c",
    ///     "ActorType": "Human",
    ///     "FullName": "Mike Dolittle",
    ///     "LastName": "Dolittle",
    ///     "FirstName": "Mike",
    ///     "LoginName": "mike.dolittle@domain1.com"
    ///   },
    ///   "RelatedWorkOrderNumber": "WO2384702937403280032",
    ///   "FinalDestination": "LINE 1"
    /// }
    /// </code>
    /// </summary>
    public class TransportOrderCompleted : CFXMessage
    {
        /// <summary>
        /// The order number of the related transport order
        /// </summary>
        public string TransportOrderNumber
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
        /// The operator who accepted the delivery, and recorded the arrival
        /// </summary>
        public Operator AcceptedBy
        {
            get;
            set;
        }

        /// <summary>
        /// The related production work order number (where applicable)
        /// </summary>
        public string RelatedWorkOrderNumber
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
