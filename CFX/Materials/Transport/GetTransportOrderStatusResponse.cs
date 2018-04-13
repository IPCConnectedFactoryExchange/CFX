using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// A response to a request to an endpoint (such as an upper level system, MES, ERP, etc.) to check
    /// the status of a particular transport order.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "TransportOrderNumber": "TR329483249830000",
    ///   "FinalDestination": "LINE 1",
    ///   "Status": "Delivered",
    ///   "History": [
    ///     {
    ///       "EventDateTime": "2017-11-01T11:55:00",
    ///       "Status": "Kitting",
    ///       "Operator": {
    ///         "OperatorIdentifier": "2252e28d-102c-4ec1-9f14-1981c1191b95",
    ///         "ActorType": "Human",
    ///         "FullName": "Bill Smith",
    ///         "LastName": "Smith",
    ///         "FirstName": "Bill",
    ///         "LoginName": "bill.smith@domain1.com"
    ///       },
    ///       "Location": "STOCK ROOM 1",
    ///       "Comments": null
    ///     },
    ///     {
    ///       "EventDateTime": "2017-11-01T14:25:00",
    ///       "Status": "Kitted",
    ///       "Operator": {
    ///         "OperatorIdentifier": "2252e28d-102c-4ec1-9f14-1981c1191b95",
    ///         "ActorType": "Human",
    ///         "FullName": "Bill Smith",
    ///         "LastName": "Smith",
    ///         "FirstName": "Bill",
    ///         "LoginName": "bill.smith@domain1.com"
    ///       },
    ///       "Location": "STOCK ROOM 1",
    ///       "Comments": null
    ///     },
    ///     {
    ///       "EventDateTime": "2017-11-01T15:45:00",
    ///       "Status": "InTransit",
    ///       "Operator": {
    ///         "OperatorIdentifier": "2252e28d-102c-4ec1-9f14-1981c1191b95",
    ///         "ActorType": "Human",
    ///         "FullName": "Bill Smith",
    ///         "LastName": "Smith",
    ///         "FirstName": "Bill",
    ///         "LoginName": "bill.smith@domain1.com"
    ///       },
    ///       "Location": "STOCK ROOM 1",
    ///       "Comments": null
    ///     },
    ///     {
    ///       "EventDateTime": "2017-11-01T16:55:00",
    ///       "Status": "InTransit",
    ///       "Operator": {
    ///         "OperatorIdentifier": "957cc475-bd65-4289-9c7a-1a89aa9adaed",
    ///         "ActorType": "Human",
    ///         "FullName": "John Doe",
    ///         "LastName": "Doe",
    ///         "FirstName": "John",
    ///         "LoginName": "john.doe@domain1.com"
    ///       },
    ///       "Location": "SMT STAGING AREA 1",
    ///       "Comments": null
    ///     },
    ///     {
    ///       "EventDateTime": "2017-11-01T17:22:00",
    ///       "Status": "Delivered",
    ///       "Operator": {
    ///         "OperatorIdentifier": "b776aee6-0462-4a7d-9976-158a342f898c",
    ///         "ActorType": "Human",
    ///         "FullName": "Mike Dolittle",
    ///         "LastName": "Dolittle",
    ///         "FirstName": "Mike",
    ///         "LoginName": "mike.dolittle@domain1.com"
    ///       },
    ///       "Location": "LINE1",
    ///       "Comments": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class GetTransportOrderStatusResponse : CFXMessage
    {
        public GetTransportOrderStatusResponse()
        {
            Result = new RequestResult();
            History = new List<TransportOrderHistory>();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The order number of the related transport order
        /// </summary>
        public string TransportOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The final destination of this transport order
        /// </summary>
        public string FinalDestination
        {
            get;
            set;
        }

        /// <summary>
        /// The current status of this transport order
        /// </summary>
        public TransportOrderStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// The history of this transport order
        /// </summary>
        public List<TransportOrderHistory> History
        {
            get;
            set;
        }
    }
}
