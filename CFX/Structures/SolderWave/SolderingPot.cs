using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Soldering pot information. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SolderingPot
    {
        /// <summary>
        /// Gets or sets the z axis setpoint.
        /// </summary>
        public double ZAxisSetpoint { get; set; }

        /// <summary>
        /// Gets or sets the z axis setpoint.
        /// </summary>
        public double ZAxisReadingValue { get; set; }

        /// <summary>
        /// Gets or sets solder pot heating information.
        /// </summary>
        public SolderPotHeating Heating { get; set; }

        /// <summary>
        /// Gets or sets SolderingWaves.
        /// </summary>
        public List<SolderingWave> SolderingWaves { get; set; }
    }
}
