using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class SolderingAggregate : Aggregate
    {
        /// <summary>
        /// Holds soldering pot information.
        /// </summary>
        public SolderingPot Pot { get; set; }
    }
}
