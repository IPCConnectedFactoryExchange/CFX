using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Heating aggregate representation. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class HeatingAggregate : Aggregate
    {
        /// <summary>
        /// An enumeration indicating the heating aggregate type.
        /// </summary>
        public HeatingAggregateType Type { get; set; }

        /// <summary>
        /// Gets or sets the setpoint of the temperature.
        /// </summary>
        public double TemperatureSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the temperature [°C] reading value.
        /// </summary>
        public double TemperatureReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the convection active set point.
        /// </summary>
        public bool ConvectionActiveSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the convection active reading value.
        /// </summary>
        public bool ConvectionActiveReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the convection increase active set point.
        /// </summary>
        public bool ConvectionIncreaseActiveSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the convection increase active reading value.
        /// </summary>
        public bool ConvectionIncreaseActiveReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the power set point.
        /// </summary>
        public double PowerSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the power reading value.
        /// </summary>
        public double PowerReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the preheating sections.
        /// </summary>
        public List<DynamicWavePreheatingSection> PreheatingSections { get; set; }
    }
}
