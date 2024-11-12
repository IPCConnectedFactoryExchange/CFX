using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// This message is the response to the corresponding StartTransferRequest
    /// <code language="none">
    /// {
    ///   "TransportOrderId": "T789012",
    ///   "Result": {
    ///     "Result": "Failed",
    ///     "ResultCode": 99,
    ///     "Message": "Failed to transfer - operation error"
    ///   }
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class StartTransferResponse : CFXMessage
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
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
    }
}
