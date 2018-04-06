using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    /// <summary>
    /// Indicates that a stencil clean operation has been performed
    /// <code language="none">
    /// {
    ///   "Stencil": {
    ///     "UniqueIdentifier": "UID23432434",
    ///     "Name": "STENCIL234343"
    ///   },
    ///   "StencilCleanMode": "V",
    ///   "TimeSinceLastClean": "00:33:00",
    ///   "CyclesSinceLastClean": 35,
    ///   "StencilCleanCycles": 2,
    ///   "StencilCleanTime": "00:00:38"
    /// }
    /// </code>
    /// </summary>
    public class StencilCleaned : CFXMessage
    {
        /// <summary>
        /// Identifies the stencil that has been cleaned
        /// </summary>
        public SMTStencil Stencil
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates that cleaning mode for the stencil clean operation
        /// </summary>
        public SMTStencilCleanMode StencilCleanMode
        {
            get;
            set;
        }


        /// <summary>
        /// Indicates the length of time that has ellapsed since the last time
        /// the stencil was cleaned
        /// </summary>
        public TimeSpan TimeSinceLastClean
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates how many printing cycles have been completed since the last
        /// time the stencil was cleaned
        /// </summary>
        public int CyclesSinceLastClean
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the total number of stencil cleaning cycles that
        /// have been performed since this squeegee was loaded.
        /// </summary>
        public int StencilCleanCycles
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the total amount of time that it took to perform this stencil clean operation
        /// </summary>
        public TimeSpan StencilCleanTime
        {
            get;
            set;
        }
    }
}
