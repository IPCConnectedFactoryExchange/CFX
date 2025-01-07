using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Types of validation topics
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum ValidationTopic
    {
        /// <summary>
        /// A validation that ensures proper tools are used
        /// </summary>
        Tools,
        /// <summary>
        /// A validation that ensures proper materials are used
        /// </summary>
        Materials,
        /// <summary>
        /// A validation that ensures proper recipe is used
        /// </summary>
        Recipe,
        /// <summary>
        /// A validation that ensures proper MaterialCarrier is used
        /// </summary>
        MaterialCarrier
    }
}
