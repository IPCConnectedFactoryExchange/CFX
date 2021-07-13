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
    /// The result of a test
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TestResult
    {
        /// <summary>
        /// The test passed
        /// </summary>
        Passed,
        /// <summary>
        /// The test failed
        /// </summary>
        Failed,
        /// <summary>
        /// The test could not be completed because an error occurred.
        /// </summary>
        Error,
        /// <summary>
        /// The test was aborted by the operator / user.
        /// </summary>
        Aborted,
        /// <summary>
        /// The test was skipped because of (virtual) bad mark
        /// </summary>
        Skipped
    }
}
