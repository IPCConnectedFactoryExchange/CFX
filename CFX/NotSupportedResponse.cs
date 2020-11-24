using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    /// <summary>
    /// Allows a CFX endpoint to indicate to the sender of a request that it is not able to answer to this particular request
    /// There can be several reasons :
    /// - Unknown request/response message : appeared in a more recent version of CFX than the one used by the endpoint
    /// - Unknown request/response message : totally unknown request (should never append)
    /// - This request/response message is not implemented in the endpoint because it is not applicable or not implemented yet
    /// <code language="none">
    /// {
    ///   "RequestResult": {
    ///     "Result": "Failed",
    ///     "ResultCode": 0,
    ///     "Message": "Unknown message"
    ///   }
    /// }
    /// </code>
    /// /// <code language="none">
    /// {
    ///   "RequestResult": {
    ///     "Result": "Failed",
    ///     "ResultCode": 0,
    ///     "Message": "Not implemented message"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class NotSupportedResponse : CFXMessage
    {
        public NotSupportedResponse()
        {
            RequestResult = new RequestResult()
            {
                Result = StatusResult.Success
            };
        }

        public RequestResult RequestResult
        {
            get;
            set;
        }
    }
}
