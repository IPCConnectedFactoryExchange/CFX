using CFX.Structures.SolderWave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// A data structure describing the set point for a particular area within a sub zone of a wave soldering machine.
    /// </summary>
    public class WaveSetPoint
    {
        /// <summary>
        /// Optional. The name of the Setpoint
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration describing the type of setpoint.
        /// </summary>
        public WaveSetPointReadingType SetPointType
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum value of this setpoint. (expressed in the appropriate units for the <seealso cref="WaveSetPointReadingType"/>).
        /// </summary>
        public double? MinValue
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum value of this setpoint. (expressed in the appropriate units for the <seealso cref="WaveSetPointReadingType"/>).
        /// </summary>
        public double? MaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// The nominal, target value of this setpoint. (expressed in the appropriate units for the <seealso cref="WaveSetPointReadingType"/>).
        /// </summary>
        public double? Setpoint
        {
            get;
            set;
        }
    }
}