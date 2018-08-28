using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.PCBInspection
{
    /// <summary>
    /// Describes the results of measurements that were made on the position of a specific PCB component.
    /// </summary>
    public class OffsetMeasurement : Measurement
    {
        /// <summary>
        /// The x offset of the component from center (in mm)
        /// </summary>
        public double DX
        {
            get;
            set;
        }

        /// <summary>
        /// The y offset of the component from center (in mm)
        /// </summary>
        public double DY
        {
            get;
            set;
        }

        /// <summary>
        /// The z offset of the component from level (in mm)
        /// </summary>
        public double DZ
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational offset on the X-Y plane (in degrees)
        /// </summary>
        public double RXY
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational offset on the Z-X plane (in degrees)
        /// </summary>
        public double RZX
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational offset on the Z-Y plane (in degrees)
        /// </summary>
        public double RZY
        {
            get;
            set;
        }
    }
}
