using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// Sent when a group of materials or production units that is being transported
    /// through the factory environment arrives at a way point along its path source
    /// to destination.
    /// <code language="none">
    /// {
    ///   "TransportOrderNumber": "TR329483249830000",
    ///   "Comments": "Arrived SMT Production Area",
    ///   "Status": "InTransit",
    ///   "TrackedBy": {
    ///     "OperatorIdentifier": "957cc475-bd65-4289-9c7a-1a89aa9adaed",
    ///     "ActorType": "Human",
    ///     "FullName": "John Doe",
    ///     "LastName": "Doe",
    ///     "FirstName": "John",
    ///     "LoginName": "john.doe@domain1.com"
    ///   },
    ///   "RelatedWorkOrderNumber": "WO2384702937403280032",
    ///   "Checkpoint": "SMT STAGING AREA 1",
    ///   "FinalDestination": "LINE 1",
    ///   "NextCheckpoint": "LINE 1"
    /// }
    /// </code>
    /// </summary>
    public class CheckpointReached : CFXMessage
    {
        /// <summary>
        /// The number of the related transport order
        /// </summary>
        public string TransportOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Human readable comments related to this arrival (where applicable)
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// The status of this transport order at the time of the event
        /// </summary>
        public TransportOrderStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// The operator who recorded the arrival (where applicable)
        /// </summary>
        public Operator TrackedBy
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
        /// The name of the check point that was reached
        /// </summary>
        public string Checkpoint
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the final destination of this transport order
        /// </summary>
        public string FinalDestination
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the next anticipated check point along the transport
        /// order's path from source to final destination
        /// </summary>
        public string NextCheckpoint
        {
            get;
            set;
        }
    }
}
