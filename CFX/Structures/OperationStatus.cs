using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Status of a performed operation, for example Calibration
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        /// <summary>
        /// Status of the operation is not known
        /// </summary>
        Unknown,
        /// <summary>
        /// The operation failed
        /// </summary>
        Failed,
        /// <summary>
        /// The operation was succesfull 
        /// </summary>
        Ok
    }
}
