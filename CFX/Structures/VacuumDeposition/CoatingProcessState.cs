using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Structure contains current process state, date, time and status type.
    /// </summary>
    public class CoatingProcessState
    {
        /// <summary>
        /// Current process state.
        /// </summary>
        public String ProcessState
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the message type of the process status sent by the endpoint.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MessageType
        {
            /// <summary>
            /// Indicates process status.
            /// </summary>
            ProcessStatus,
            /// <summary>
            /// Indicates process error.
            /// </summary>
            ProcessError,
        }
    }
}
