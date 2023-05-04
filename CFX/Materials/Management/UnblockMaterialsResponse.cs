using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Response to a request to unblock one or more particular lots or instances of material from use in production.
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
    public class UnblockMaterialsResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnblockMaterialsResponse()
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
