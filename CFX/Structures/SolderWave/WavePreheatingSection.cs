using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// Preheating section information.
    /// </summary>
    public class WavePreheatingSection
    {
        public double PowerSetValue { get; set; }

        /// <summary>
        /// Gets or sets the power reading point.
        /// </summary>
        public double PowerReadingPoint { get; set; }

        /// <summary>
        /// Gets or sets the temperature reading value.
        /// </summary>
        public double TemperatureReadingValue { get; set; }
    }
}
