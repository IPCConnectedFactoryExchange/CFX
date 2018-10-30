using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is aligned (located / positioned) within a stage
    /// of an endpoint prior to the commencement of work.
    /// </summary>
    public class UnitAlignmentActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitAlignmentActivity()
        {
            ActivityName = "UNIT ALIGNMENT";
            ValueAddType = ValueAddType.NonValueAdd;
        }

        /// <summary>
        /// The amount of correction applied in the X axis, express in millimeters (mm)
        /// </summary>
        public double DX
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of correction applied in the Y axis, express in millimeters (mm)
        /// </summary>
        public double DY
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of correction applied in the Z axis, express in millimeters (mm)
        /// </summary>
        public double DZ
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational correction applied in the X-Y plane (in degrees)
        /// </summary>
        public double DXY
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational correction applied in the Z-X plane (in degrees)
        /// </summary>
        public double DZX
        {
            get;
            set;
        }

        /// <summary>
        /// The counter-clockwise rotational correction applied in the Z-Y plane (in degrees)
        /// </summary>
        public double DZY
        {
            get;
            set;
        }
    }
}
