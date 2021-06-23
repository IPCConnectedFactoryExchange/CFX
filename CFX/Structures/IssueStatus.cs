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
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// An enumeration which describes the lifecycle of an issue, such as a Defect or Symptom
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("1.4")]
    public enum IssueStatus
    {
        /// <summary>
        /// The issue is newly discovered
        /// </summary>
        NewlyDiscovered,
        /// <summary>
        /// The issue has been confirmed
        /// </summary>
        Confirmed,
        /// <summary>
        /// The issue is not confirmed, and considered to be invalid (false defect, symptom, etc.)
        /// </summary>
        False,
        /// <summary>
        /// The issue has been repaired
        /// </summary>
        Repaired,
        /// <summary>
        /// The issue has been fully resolved, and closed
        /// </summary>
        Closed
    }
}
