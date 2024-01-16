using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public class Aggregate
    {
        /// <summary>
        /// Determines weather the stage (module) was during the processing active or not.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the process time reading value.
        /// </summary>
        public TimeSpan ProcessTimeReadingValue { get; set; }

        /// <summary>
        /// A friendly name for this Aggregate
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sequence of this Aggregate in the machine
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// An enumeration indicating the purpose of this particular stage
        /// </summary>
        public AggregateType Type { get; set; }

        /// <summary>
        /// An enumeration indicating the location of the aggregate.
        /// </summary>
        public AggregateLocation Location { get; set; }
    }
}
