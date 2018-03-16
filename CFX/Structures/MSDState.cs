using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Possible states of packages of moisture sensitive devices
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MSDState
    {
        /// <summary>
        /// Unspecified state
        /// </summary>
        Unspecified,
        /// <summary>
        /// Sealed and never opened.
        /// </summary>
        NeverOpened,
        /// <summary>
        /// Open and exposed to the atmosphere
        /// </summary>
        Exposed,
        /// <summary>
        /// Open but stored in low humidity environment
        /// </summary>
        InDryStorage,
        /// <summary>
        /// Exposed to atmosphere/moisture beyond acceptable limits.
        /// </summary>
        Expired
    }
}
