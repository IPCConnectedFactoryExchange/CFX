using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to discover all of the other endpoints participating in this CFX network, 
    /// and their capabilities. All other CFX endpoints must then respond to this broadcast, providing
    /// information about themselves.  The response provides basic information about the endpoint, 
    /// including its CFX Handle and network hostname / address.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "CFXHandle": "SMTPlus.Model_21232.SN23123",
    ///   "RequestNetworkUri": "amqp://host33/",
    ///   "RequestTargetAddress": "/queue/SN23123"
    /// }
    /// </code>
    /// </summary>
    public class WhoIsThereResponse : CFXMessage
    {
        public WhoIsThereResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// Result of the request.
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The handle of the endpoint that is responding
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }

        /// <summary>
        /// The network address / Uri to be used for requests to this endpoint
        /// </summary>
        public string RequestNetworkUri
        {
            get;
            set;
        }

        /// <summary>
        /// The AMQP 1.0 target address to be used for requests to this endpoint
        /// </summary>
        public string RequestTargetAddress
        {
            get;
            set;
        }
    }
}
