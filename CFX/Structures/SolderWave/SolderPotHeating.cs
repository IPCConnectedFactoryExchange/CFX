using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Holds information about the solder pot heating.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SolderPotHeating
    {
        /// <summary>
        /// Gets or sets the set point of the temperature [°C].
        /// </summary>
        public double TemperatureSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the temperature [°C] reading value.
        /// </summary>
        public double TemperatureReadingValue { get; set; }
    }
}
