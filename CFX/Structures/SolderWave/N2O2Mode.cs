using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of N2O2 modes.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum N2O2Mode
    {
        /// <summary>
        /// Disable N202.
        /// </summary>
        Off,
        /// <summary>
        /// Enable N2.
        /// </summary>
        N2On,
        /// <summary>
        /// Enable N202.
        /// </summary>
        N2O2On,
        /// <summary>
        /// Enable 02 for Pot1.
        /// </summary>
        O2Pot1,
        /// <summary>
        /// Enable 02 for Pot2.
        /// </summary>
        O2Pot2
    }
}
