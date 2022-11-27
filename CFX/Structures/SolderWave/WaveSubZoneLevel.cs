using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// An enumeration indicating the nature of a <seealso cref="WaveSetPoint"/> or <seealso cref="WaveReading"/> within a wave soldering zone <seealso cref="WaveZone"/>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaveSubZoneLevel
    {
        /// <summary>
        /// Applies to the entire zone.
        /// </summary>
        WholeZone,
        /// <summary>
        /// The subzone is on mid or in the same heigth as the solder frame or Pcba e.g. a conveyor.
        /// </summary>
        Middle,
        /// <summary>
        /// The subzone is above the solder frame or PCBA
        /// </summary>
        Top,
        /// <summary>
        /// The subzone is below the solder frame or PCBA
        /// </summary>
        Bottom,
    }
}