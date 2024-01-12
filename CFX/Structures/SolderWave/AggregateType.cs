using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SolderWave
{
    public enum AggregateType
    {
        /// <summary>
        /// Work on production units is performed at this stage. This may be any sort of work, including assembly, inspection, processing, etc.
        /// </summary>
        Work = 0,

        /// <summary>
        /// This stage is intended to serve as a buffer for production units. No work is performed at this stage. 
        /// </summary>
        Buffer = 1
    }
}
