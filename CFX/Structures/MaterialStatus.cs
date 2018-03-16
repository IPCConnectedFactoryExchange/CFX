using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Status of a material package
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaterialStatus
    {
        /// <summary>
        /// Material is available for use in production
        /// </summary>
        Active,
        /// <summary>
        /// Material has been blocked, and should not be used in production
        /// </summary>
        Blocked,
        /// <summary>
        /// Material has been exhausted, and can no longer be used in production
        /// </summary>
        Depleted
    }
}
