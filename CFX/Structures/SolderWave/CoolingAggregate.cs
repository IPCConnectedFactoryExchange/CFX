using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Cooling aggregate representation. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class CoolingAggregate : Aggregate
    {
        /// <summary>
        /// An enumeration indicating the cooling type.
        /// </summary>
        public CoolingType CoolingType { get; set; }
    }
}
