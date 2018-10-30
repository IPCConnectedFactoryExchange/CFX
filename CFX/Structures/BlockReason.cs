using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Reasons why a unit is blocked
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlockReason
    {
        /// <summary>
        /// No reason specified
        /// </summary>
        Unspecified,
        /// <summary>
        /// There exists suspicion that the material or unit may be defective or otherwise problematic
        /// </summary>
        SuspectedProblem,
        /// <summary>
        /// The material or unit is known to be defective.
        /// </summary>
        Defective,
        /// <summary>
        /// A material has expired, and can no longer be utilized.
        /// </summary>
        ExpiredMaterial,
        /// <summary>
        /// A tool has expired, and can no longer be utilized.
        /// </summary>
        ExpiredTool,
    }
}
