using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// An enumeration that indicates what the subzone represents.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaveSubZoneType
    {
        /// <summary>
        /// The subzone type is unknown 
        /// </summary>
        Unknown,
        /// <summary>
        /// The subzone is a convection heater
        /// </summary>
        Convection,
        /// <summary>
        /// The subzone is a conveyor for solder frames
        /// </summary>
        SolderFrameConveyor,
        /// <summary>
        /// The subzone is a conveyor for direct proccessing of PCBAs or solder masks
        /// </summary>
        FingerConveyor,
        /// <summary>
        /// The subzone is a cooling zone
        /// </summary>
        Cool,
        /// <summary>
        /// The subzone is fluxer zone
        /// </summary>
        Flux,
        /// <summary>
        /// The subzone is a infrared heater. 
        /// </summary>
        Infrared,
        /// <summary>
        /// The subzone is a residual oxygen sensor
        /// </summary>
        ResidualOxygen,
        /// <summary>
        /// The subzone is a nitrogen regulator
        /// </summary>
        Nitrogen,
        /// <summary>
        /// The subzone is the solder wave
        /// </summary>
        SolderWave,
    }
}