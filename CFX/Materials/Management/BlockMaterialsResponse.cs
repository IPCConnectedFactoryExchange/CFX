using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Response to a request block one or more instances of material from use in production
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
    public class BlockMaterialsResponse : CFXMessage
    {
        public BlockMaterialsResponse()
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
