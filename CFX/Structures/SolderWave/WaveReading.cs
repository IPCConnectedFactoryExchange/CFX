using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// Structure that describes the setpoints and key actuals of a particular area
    /// within a particular zone of a wave soldering machine.
    /// </summary>
    public class WaveReading
    {
        /// <summary>
        /// Optional. The name of the Reading.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration that describes a particular area within a particular zone of a reflow oven.
        /// </summary>
        public WaveSubZoneType SubZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration describing the type of reading.
        /// </summary>
        /// <remarks>The reading type uses the same enum like the <seealso cref="WaveSetPoint"/></remarks>
        public WaveSetPointReadingType ReadingType
        {
            get;
            set;
        }

        /// <summary>
        /// The value of the reading (expressed in the appropriate units for the <seealso cref="ReadingType"/>).
        /// </summary>
        public double? ReadingValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum acceptable value
        /// </summary>
        public double? MinimumAcceptableValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum acceptable value
        /// </summary>
        public double? MaximumAcceptableValue
        {
            get;
            set;
        }
    }
}
