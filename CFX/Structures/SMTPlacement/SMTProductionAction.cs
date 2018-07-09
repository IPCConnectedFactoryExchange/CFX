using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Possible action in production (applicable for a unit)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTProductionAction
    {
        /// <summary>
        /// Manual operation on the unit
        /// </summary>
        ManualOperation,
        /// <summary>
        /// Board Conveying for a unit
        /// </summary>
        BoardConveying,
        /// <summary>
        /// Board alignment for a unit
        /// </summary>
        BoardAlignment,
        /// <summary>
        /// Placement on a unit
        /// </summary>
        Placement,
    }
}