using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.UVCuring
{
    /// <summary>
    /// Properties of glass plate.
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    public class UVCuringGlassPlate
    {
        /// <summary>
        /// Row of the glas plate
        /// </summary>
        public int Row { get; set; }


        /// <summary>
        /// Is the glas plate present
        /// </summary>
        public bool IsPresent { get; set; }
    }
}
