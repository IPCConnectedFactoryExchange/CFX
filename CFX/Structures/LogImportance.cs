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
    /// Importance of an event log entry
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogImportance
    {
        /// <summary>
        /// Useful for debugging purposes
        /// </summary>
        Debug,
        /// <summary>
        /// General information
        /// </summary>
        Information,
        /// <summary>
        /// Warning
        /// </summary>
        Warning,
        /// <summary>
        /// Recoverable error
        /// </summary>
        Error,
        /// <summary>
        /// Error that caused an unrecoverable condition
        /// </summary>
        Fatal
    }
}
