using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class SolderPotHeating
    {
        /// <summary>
        /// Gets or sets the set point of the temperature.
        /// </summary>
        public double TemperatureSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the temperature reading value.
        /// </summary>
        public double TemperatureReadingValue { get; set; }
    }
}
