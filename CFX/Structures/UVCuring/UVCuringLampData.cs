using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.UVCuring
{
    /// <summary>
    /// Properties of an UV lamp. 
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    public class UVCuringLampData
    {
        /// <summary>
        /// Row of the lamp
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Column of the lamp
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// State of the lamp
        /// </summary>
        public UVCuringLampState UVCuringLampState { get; set; }
    }
}
