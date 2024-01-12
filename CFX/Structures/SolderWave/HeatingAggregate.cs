using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class HeatingAggregate : Aggregate
    {
        public HeatingAggregateType Type { get; set; }

        public double TemperatureSetpoint { get; set; }

        public double TemperatureReadingValue { get; set; }

        public bool ConvectionActiveSetpoint { get; set; }

        public bool ConvectionActiveReadingValue { get; set; }

        public bool ConvectionIncreaseActiveSetpoint { get; set; }

        public bool ConvectionIncreaseActiveReadingValue { get; set; }

        public double PowerSetpoint { get; set; }

        public double PowerReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the preheating sections.
        /// </summary>
        public List<DynamicWavePreheatingSection> PreheatingSections { get; set; }
    }
}
