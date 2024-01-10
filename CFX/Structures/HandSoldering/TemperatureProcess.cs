namespace CFX.Structures.HandSoldering
{
    public class TemperatureProcess
    {
     
        /// <summary>
        /// The temperature unit.
        /// </summary>
        public TemperatureUnit Type { get; set; }

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
