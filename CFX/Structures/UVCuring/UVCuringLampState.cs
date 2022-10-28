using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.UVCuring
{
    /// <summary>
    /// An enumeration indicating the state of lamp.
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("1.6")]
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
