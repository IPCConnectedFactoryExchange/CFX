using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// An enumeration indicating different types of SMT heads that might exist at an endpoint.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTHeadType
    {
        /// <summary>
        /// Turret head type
        /// </summary>
        Turret,
        /// <summary>
        /// Pulsar head type
        /// </summary>
        Pulsar,
    }
}
