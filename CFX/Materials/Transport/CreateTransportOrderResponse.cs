using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Message response for a corresponding transport order request.
    /// <code language="none">
    /// {
    ///   "TransportOrderId": "T123456",
    ///   "FleetManagerTransportOrderId": "FL12345",
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "Ok"
    ///   }
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class CreateTransportOrderResponse : CFXMessage
    {
        /// <summary>
        /// The order ID of the queried transport order
        /// </summary>
        public string TransportOrderId
        {
            get;
            set;
        }
        /// <summary>
        /// The order ID created by the Fleet Manager for this transport order
        /// </summary>
        public string FleetManagerTransportOrderId
        {
            get;
            set;
        }
        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
    }
}
