using System;

namespace CFX.Structures.HandSoldering
{
    public class TelemetryData
    {
        /// <summary>
        /// Creation timestamp of the telemetry data.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The current power output (percentage 0 to 100).
        /// </summary>
        public int ActualPower { get; set; }

        /// <summary>
        /// The current temperature process.
        /// </summary>
        public TemperatureProcess TemperatureProcess { get; set; }
    }
}
