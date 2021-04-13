using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    /// <summary>
    /// A response to a request by a remote party for a stencil printer to perform a
    /// stencil clean operation
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
    public class CleanStencilResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CleanStencilResponse()
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
