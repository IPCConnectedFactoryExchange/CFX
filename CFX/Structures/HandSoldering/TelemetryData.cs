using System;

namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Telemetry data.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
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
