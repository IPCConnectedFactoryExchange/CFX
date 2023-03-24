using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Response to a request that the operator's login was successful or not.
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
    public class ValidateOperatorResponse : CFXMessage
    {
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
