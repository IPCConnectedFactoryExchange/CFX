using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
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
