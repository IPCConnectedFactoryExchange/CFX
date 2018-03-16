using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of data
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataType
    {
        /// <summary>
        /// Text based data
        /// </summary>
        String,
        /// <summary>
        /// A list of test based data
        /// </summary>
        StringList,
        /// <summary>
        /// Numeric data (floating point)
        /// </summary>
        Numeric,
        /// <summary>
        /// Numeric data (integer / non-floating point)
        /// </summary>
        Integer,
        /// <summary>
        /// True or False data
        /// </summary>
        Boolean,
        /// <summary>
        /// A single value selected from a list of possibilities
        /// </summary>
        Enumeration,
        /// <summary>
        /// An array of bytes
        /// </summary>
        Binary,
        /// <summary>
        /// A 128-bit globallyt unique integer based numeric value
        /// </summary>
        Guid
    }
}
