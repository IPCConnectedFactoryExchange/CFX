using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.LaserMarking
{
    /// <summary>
    /// Provides information about the conditions within a reflow oven at a given point in time.
    /// </summary>
    public class LaserMarkingProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LaserMarkingProcessData()
        {
        }

        /// <summary>
        /// Total amount of time that the laser was used during processing.
        /// </summary>
        public TimeSpan LaserProcessingTime
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the active recipe at the time when the processing occurred.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }
    }
}
