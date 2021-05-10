using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The result of a test validation operation
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TestValidationStatus
    {
        /// <summary>
        /// The test validation has succeeded
        /// </summary>
        Passed,
        /// <summary>
        /// The test validation has failed (not succeeded)
        /// </summary>
        Failed,
        /// <summary>
        /// The test validation has skipped because of (virtual) bad mark
        /// </summary>
        Skipped
    }
}
