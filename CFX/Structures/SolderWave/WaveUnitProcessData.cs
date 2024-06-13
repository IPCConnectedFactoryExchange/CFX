using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Wave unit process data information.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class WaveUnitProcessData
    {
        /// <summary>
        /// Gets or sets the flux stages.
        /// </summary>
        public List<FluxAggregate> FluxAggregates { get; set; }

        /// <summary>
        /// Gets or sets the preheating stages.
        /// </summary>
        public List<PreheatingAggregate> PreheatingAggregates { get; set; }

        /// <summary>
        /// Gets or sets the soldering stages.
        /// </summary>
        public List<SolderingAggregate> SolderingAggregates { get; set; }

        /// <summary>
        /// Gets or sets the cooling stages.
        /// </summary>
        public List<CoolingAggregate> CoolingAggregates { get; set; }
    }
}
