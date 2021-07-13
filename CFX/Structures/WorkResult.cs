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
    /// The result of an operation where work was performed on a production unit
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WorkResult
    {
        /// <summary>
        /// The work was completed successfully
        /// </summary>
        Completed,
        /// <summary>
        /// The work was completed, but with an undesireable result
        /// </summary>
        Failed,
        /// <summary>
        /// Work was not completed
        /// </summary>
        Aborted,
        /// <summary>
        /// The test was skipped because of (virtual) bad mark
        /// </summary>
        Skipped
    }
}
