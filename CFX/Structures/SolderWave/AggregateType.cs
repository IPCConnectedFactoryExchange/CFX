using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of aggregate types. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum AggregateType
    {
        /// <summary>
        /// Work on production units is performed at this stage.
        /// </summary>
        Work = 0,

        /// <summary>
        /// No work is performed at this stage – intended to serve buffer. 
        /// </summary>
        Buffer = 1
    }
}
