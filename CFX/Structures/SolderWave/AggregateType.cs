using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
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
