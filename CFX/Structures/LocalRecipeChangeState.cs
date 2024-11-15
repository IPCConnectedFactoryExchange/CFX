using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// State of a local recipe change
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LocalRecipeChangeState
    {
        /// <summary>
        /// The change is effective.
        /// </summary>
        Activated,
        /// <summary>
        /// The change is removed back.
        /// </summary>
        Deactivated
    }
}
