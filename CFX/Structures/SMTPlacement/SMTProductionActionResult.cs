using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The result of an operation where action was performed on a production unit
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTProductionActionResult
    {
        /// <summary>
        /// The action was completed successfully
        /// </summary>
        Completed,
        /// <summary>
        /// The action was completed, but with an undesireable result
        /// </summary>
        Failed,
        /// <summary>
        /// Action was not completed
        /// </summary>
        Aborted
    }
}
