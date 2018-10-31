using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Response to an external source to modify the behaviour for the equipment to guide the operator process endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class HandleFaultResponse : CFXMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandleFaultResponse"/> class.
        /// </summary>
        public HandleFaultResponse()
        {
            Result = new RequestResult();
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
