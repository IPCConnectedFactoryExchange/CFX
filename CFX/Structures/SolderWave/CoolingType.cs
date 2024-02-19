using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of cooling types. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum CoolingType
    {
        /// <summary>
        /// Cooling by means of blowpipe cooling.
        /// </summary>
        BlowpipeCooling,
        /// <summary>
        /// Cooling by means of cooling blower.
        /// </summary>
        CoolingBlowerSwitched,
        /// <summary>
        /// Cooling using heat exchanger.
        /// </summary>
        HeatExchanger
    }
}
