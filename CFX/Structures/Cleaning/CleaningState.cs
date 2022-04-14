using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// Cleaning states (e.g., used by stencil, squeegee)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CleaningState
    {
        /// <summary>
        /// Unknown cleaning status
        /// </summary>
        Unknown,
        /// <summary>
        /// Tool cleaned
        /// </summary>
        Cleaned,
        /// <summary>
        /// Tool not cleaned
        /// </summary>
        NotCleaned
    }
}