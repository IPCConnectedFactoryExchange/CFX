using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// Structure that describes the setpoints and key actuals of a particular area
    /// within a particular zone of a reflow oven.
    /// </summary>
    public class ReflowReading
    {
        /// <summary>
        /// An enumeration that describes a particular area within a particular zone of a reflow oven.
        /// </summary>
        public ReflowSubZoneType SubZone
        {
            get;
            set;
        }

        public ReflowReadingType ReadingType
        {
            get;
            set;
        }

        /// <summary>
        /// The value of the reading (expressed in the appropriate units for the ReadingType).
        /// </summary>
        public double? ReadingValue
        {
            get;
            set;
        }
    }
}
