using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// N2 representation. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class N2
    {
        public N2Mode Mode { get; set; }

        /// <summary>
        /// Gets or sets the nitrogen supply reading value in mbar.
        /// </summary>
        public double NitrogenSupplyReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the flow volume reading value in m³/h.
        /// </summary>
        public double FlowVolumeReadingValue { get; set; }

        public List<N2Measurement> Measurements { get; set; }
    }
}
