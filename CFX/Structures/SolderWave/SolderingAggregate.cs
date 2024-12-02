using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Soldering aggregate representation. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class SolderingAggregate : Aggregate
    {
        /// <summary>
        /// Holds soldering pot information.
        /// </summary>
        public SolderingPot Pot { get; set; }
    }
}
