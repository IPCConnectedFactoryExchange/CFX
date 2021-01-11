using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    /// <summary>
    /// Response to a request from an external source for a squeegee clean
    /// operation to be performed
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
    public class CleanSqueegeeResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CleanSqueegeeResponse()
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
