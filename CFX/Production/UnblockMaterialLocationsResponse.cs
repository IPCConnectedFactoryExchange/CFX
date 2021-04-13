using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Response to UnblockMaterialLocationsRequest
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "BLOCKED OK"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class UnblockMaterialLocationsResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnblockMaterialLocationsResponse()
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
