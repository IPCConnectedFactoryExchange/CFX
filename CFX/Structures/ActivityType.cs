using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The generic type of activity
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActivityType
    {
        /// <summary>
        /// Board loading
        /// </summary>
        BoardLoading,
        /// <summary>
        /// Board unloading
        /// </summary>
        BoardUnloading
    }
}
