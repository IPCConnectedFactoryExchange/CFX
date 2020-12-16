using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// A structure which indicates whether or not a CFX request to an endpoint was successful.
    /// If not successful, information about the nature of the failure is provided.
    /// </summary>
    public class RequestResult
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RequestResult() { }

        /// <summary>
        /// An enumeration indication whether or not the request was successfully executed
        /// </summary>
        public StatusResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// In the case of a failure, an integer-based, endpoint-specific error code
        /// indicating the nature of the failure
        /// </summary>
        public int ResultCode
        {
            get;
            set;
        }

        /// <summary>
        /// In the case of a failure, a human readable message indicating the nature of the failure
        /// </summary>
        public string Message
        {
            get;
            set;
        }
    }
}
