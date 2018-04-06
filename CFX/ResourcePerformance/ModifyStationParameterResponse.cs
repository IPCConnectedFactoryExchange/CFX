using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Response to an external source to modify a generic configuration parameter of a process endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "ParameterName": "Torque1",
    ///   "OldParameterValue": "22.6",
    ///   "NewParameterValue": "35.6"
    /// }
    /// </code>
    /// </summary>
    public class ModifyStationParameterResponse : CFXMessage
    {
        public ModifyStationParameterResponse()
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

        /// <summary>
        /// THe name of the configuration setting that was modified
        /// </summary>
        public string ParameterName
        {
            get;
            set;
        }

        /// <summary>
        /// The previous value of the configuration setting
        /// </summary>
        public string OldParameterValue
        {
            get;
            set;
        }

        /// <summary>
        /// The new value of the configuration setting
        /// </summary>
        public string NewParameterValue
        {
            get;
            set;
        }
    }
}
