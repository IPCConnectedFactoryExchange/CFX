using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.UVCuring
{
    /// <summary>
    /// An enumeration indicating the nature of a zone within a reflow oven
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UVCuringLampState
    {
        /// <summary>
        /// Lamp is on 
        /// </summary>
        On,
        /// <summary>
        /// Lamp is off 
        /// </summary>
        Off,
        /// <summary>
        /// Lamp has an error 
        /// </summary>
        Error
    }
}
