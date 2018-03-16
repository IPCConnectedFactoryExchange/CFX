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
    /// The severity of a fault
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FaultSeverity
    {
        /// <summary>
        /// Informational purposes.  No stoppage.
        /// </summary>
        Information,
        /// <summary>
        /// Warning.  No stoppage
        /// </summary>
        Warning,
        /// <summary>
        /// Error.  Stoppage.
        /// </summary>
        Error,
        /// <summary>
        /// Safety related Error.  Stoppage.
        /// </summary>
        Alarm,
    }
}
