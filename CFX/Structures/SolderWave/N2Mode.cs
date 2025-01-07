﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of N2 modes.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum N2Mode
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
        /// Enable N2 for Pot1.
        /// </summary>
        N2Pot1,
        /// <summary>
        /// Enable N2 for Pot2.
        /// </summary>
        N2Pot2
    }
}
