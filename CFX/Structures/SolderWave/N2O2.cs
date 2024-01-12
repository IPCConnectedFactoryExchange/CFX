using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class N2O2
    {
        public N2O2Mode Mode { get; set; }

        /// <summary>
        /// Gets or sets the nitrogen supply reading value in mbar.
        /// </summary>
        public double NitrogenSupplyReadingValue { get; set; }

        /// <summary>
        /// Gets or sets the flow volume reading value in m³/h.
        /// </summary>
        public double FlowVolumeReadingValue { get; set; }

        public List<N2O2Measurement> Measurements { get; set; }
    }
}
