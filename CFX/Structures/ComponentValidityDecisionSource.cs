using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// Types of component validity decision source
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentValidityDecisionSource
    {
        /// <summary>
        /// Unknown validity decision source for the component
        /// </summary>
        Unkwnown,
        /// <summary>
        /// The component rejection is based on the check of the measurements.
        /// If at least one measurement is out of range, the component is rejected.
        /// </summary>
        Measurements,
        /// <summary>
        /// An algorithm is responsible of the decision to reject the component or not
        /// </summary>
        Algorithm,
        /// <summary>
        /// The operator is responsible of the decision to reject the component or not
        /// </summary>
        Operator,
    }
}
