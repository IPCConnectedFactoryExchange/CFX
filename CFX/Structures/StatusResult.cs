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
        /// Successful completion of operation
        /// </summary>
        Success,
        /// <summary>
        /// A portion of the request completed successfully (another portion did not).
        /// Where applicable, the response message will contain details on the portion that did 
        /// not succeed.
        /// </summary>
        PartialSuccess,
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
