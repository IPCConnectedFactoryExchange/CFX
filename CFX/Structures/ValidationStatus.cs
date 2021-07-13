using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The result of a validation operation
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValidationStatus
    {
        /// <summary>
        /// The validation has succeeded
        /// </summary>
        Passed,
        /// <summary>
        /// The validation has failed (not succeeded)
        /// </summary>
        Failed,
        /// <summary>
        /// The validation has skipped because of (virtual) bad mark
        /// </summary>
        Skipped
    }
}
