using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the state of a work order action.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WorkOrderActionState
    {
        /// <summary>
        /// The work order action has started, but is not yet complete.
        /// </summary>
        Started,
        /// <summary>
        /// The work order action was aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// The work order action successfullly completed.
        /// </summary>
        Completed
    }
}
