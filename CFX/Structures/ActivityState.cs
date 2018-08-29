using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The state of an activity
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActivityState
    {
        /// <summary>
        /// The activity is started
        /// </summary>
        Started,
        /// <summary>
        /// The activity is paused
        /// </summary>
        Paused,
        /// <summary>
        /// The activity is resumed
        /// </summary>
        Resumed,
        /// <summary>
        /// The activity is completed
        /// </summary>
        Completed
    }
}
