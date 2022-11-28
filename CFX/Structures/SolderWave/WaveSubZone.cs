using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// A data structure for describing a sub zone of the soldering wave machine. Inherits from <seealso cref="Stage"/>.
    /// </summary>
    public class WaveSubZone : Stage
    {


        /// <summary>
        /// Default constructor. Inherits from <see cref="Stage"/>. Set also <seealso cref="StageType"/> to <seealso cref="StageType.Work"/>.
        /// </summary>
        public WaveSubZone()
        {
            WaveSetPoints = new List<WaveSetPoint>();
            WaveReadings = new List<WaveReading>();
            StageType = StageType.Work;
        }

        /// <summary>
        /// The area within the zone to which the setpoint applies.
        /// </summary>
        public WaveSubZoneType SubZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// The level on which the subzone is located.
        /// </summary>
        public WaveSubZoneLevel SubZoneLevel
        {
            get;
            set;
        }

        /// <summary>
        /// A list of current setpoints associated with this subzone.
        /// </summary>
        public List<WaveSetPoint> WaveSetPoints
        {
            get;
            set;
        }

        /// <summary>
        /// A list of current readings associated with this subzone.
        /// </summary>
        public List<WaveReading> WaveReadings
        {
            get;
            set;
        }
    }
}
