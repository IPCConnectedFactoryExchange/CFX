namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Temperature process information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class TemperatureProcess
    {
        /// <summary>
        /// The temperature unit.
        /// </summary>
        public TemperatureUnit TemperatureUnit { get; set; }

        /// <summary>
        /// The set target temperature.
        /// </summary>
        public int TargetTemperature { get; set; }

        /// <summary>
        /// The current temperature.
        /// </summary>
        public int CurrentTemperature { get; set; }
    }
}
