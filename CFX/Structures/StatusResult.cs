using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Result of an operation
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusResult
    {
        /// <summary>
        /// Unknown result
        /// </summary>
        Unspecified,
        /// <summary>
        /// Successful completion of operation
        /// </summary>
        Success,
        /// <summary>
        /// Operation was not completed successfully
        /// </summary>
        Failed,
        /// <summary>
        /// Operation successful but with warning(s)
        /// </summary>
        Warning
    }
}
