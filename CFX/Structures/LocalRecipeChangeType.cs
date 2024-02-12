using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Type of a local recipe change
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LocalRecipeChangeType
    {
        /// <summary>
        /// Unit skip or unskip (UnitSkipProductionChange).
        /// </summary>
        UnitSkip,
        /// <summary>
        /// Component removal or restoration (ComponentRemovalProductionChange).
        /// </summary>
        ComponentRemoval,
        /// <summary>
        /// Use or not an alternative component (ComponentAlternativeProductionChange).
        /// </summary>
        ComponentAlternative,
        /// <summary>
        /// New teaching of a fiducial
        /// </summary>
        FiducialTeach
    }
}