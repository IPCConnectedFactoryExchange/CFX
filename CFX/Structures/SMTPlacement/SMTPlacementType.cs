using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// An enumeration indicating different types of placement for an SMT machine
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTPlacementType
    {
        /// <summary>
        /// Manual placement
        /// </summary>
        Manual,
        /// <summary>
        /// Step by step placement
        /// </summary>
        StepByStep,
        /// <summary>
        /// Automatic placement
        /// </summary>
        Automatic,
    }
}
