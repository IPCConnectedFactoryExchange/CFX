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
    /// The overall result of processing performed on a production unit in the course of production.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProcessingResult
    {
        /// <summary>
        /// The processing succeeded
        /// </summary>
        Succeeded,
        /// <summary>
        /// The processing failed
        /// </summary>
        Failed,
        /// <summary>
        /// The processing could not be completed because an error occurred.
        /// </summary>
        Error,
        /// <summary>
        /// The processing was aborted by the operator / user.
        /// </summary>
        Aborted,
        /// <summary>
        /// The test was skipped because of (virtual) bad mark
        /// </summary>
        Skipped
    }
}
