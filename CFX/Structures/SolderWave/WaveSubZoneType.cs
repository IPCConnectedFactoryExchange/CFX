using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// An enumeration that indicates what the sub zone represents.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaveSubZoneType
    {
        /// <summary>
        /// The sub zone type is unknown 
        /// </summary>
        Unknown,
        /// <summary>
        /// The sub zone is a convection heater
        /// </summary>
        Convection,
        /// <summary>
        /// The sub zone is a conveyor for solder frames
        /// </summary>
        SolderFrameConveyor,
        /// <summary>
        /// The sub zone is a conveyor for direct proccessing of PCBAs or solder masks
        /// </summary>
        FingerConveyor,
        /// <summary>
        /// The sub zone is a cooling zone
        /// </summary>
        Cool,
        /// <summary>
        /// The sub zone is fluxer zone
        /// </summary>
        Flux,
        /// <summary>
        /// The sub zone is a infrared heater. 
        /// </summary>
        Infrared,
        /// <summary>
        /// The sub zone is a residual oxygen sensor
        /// </summary>
        ResidualOxygen,
        /// <summary>
        /// The sub zone is a nitrogen regulator
        /// </summary>
        Nitrogen,
        /// <summary>
        /// The sub zone is the solder wave
        /// </summary>
        SolderWave,
    }
}