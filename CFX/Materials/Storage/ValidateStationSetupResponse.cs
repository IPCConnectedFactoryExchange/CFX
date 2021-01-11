using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Response to a request to a process endpoint to validate that the currently loaded materials
    /// comply with the setup requirements supplied by the request.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "SETUP OK"
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class ValidateStationSetupResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ValidateStationSetupResponse()
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
