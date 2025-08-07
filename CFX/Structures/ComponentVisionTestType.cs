using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Describe the type of a vision test
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentVisionTestType
    {
        /// <summary>
        /// Unknown vision test type
        /// </summary>
        Unkwnown,
        /// <summary>
        /// Vision test of the component before the pickup
        /// </summary>
        BeforePickup,
        /// <summary>
        /// Vision test of the component after the pickup
        /// </summary>
        AfterPickup,
        /// <summary>
        /// Vision test of the component after the electrical test
        /// </summary>
        AfterElectricalTest,
    }
}
