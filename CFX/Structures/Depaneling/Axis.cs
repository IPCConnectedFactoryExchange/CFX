using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Depaneling
{
    /// <summary>
    /// Represents an axis on a depaneling / router type machine.
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class Axis
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Axis()
        {

        }

        /// <summary>
        /// Name of the Axis 
        /// </summary>
        public string AxisName
        {
            get;
            set;
        }

        /// <summary>
        /// Max axis speed in mm/s
        /// </summary>
        public decimal ActualAxisSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Set value in (mm/s2)
        /// <summary>
        public decimal AxisAcceleration_SetValue
        {
            get;
            set;
        }

        /// <summary>
        /// Set value in (mm/s2)
        /// </summary>
        public decimal AxisDecceleration_SetValue
        {
            get;
            set;
        }

        /// <summary>
        /// Operating at Maximum speed.
        /// </summary>
        public decimal ActualMaxVelocity
        {
            get;
            set;
        }
    }
}
