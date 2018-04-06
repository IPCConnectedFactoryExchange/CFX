using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    /// <summary>
    /// Indicates that a squeegee clean operation has been performed
    /// <code language="none">
    /// {
    ///   "Squeegee": {
    ///     "UniqueIdentifier": "UID23432434",
    ///     "Name": "STENCIL234343"
    ///   },
    ///   "SqueegeeCleanType": "Normal",
    ///   "TimeSinceLastClean": "00:33:00",
    ///   "CyclesSinceLastClean": 35,
    ///   "SqueegeeCleanCycles": 2,
    ///   "SqueegeeCleanTime": "00:00:38"
    /// }
    /// </code>
    /// </summary>
    public class SqueegeeCleaned : CFXMessage
    {
        /// <summary>
        /// Identifies the squeegee that has been cleaned
        /// </summary>
        public SMTSqueegee Squeegee
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the type of clean that was performed
        /// </summary>
        public SMTSqueegeeCleanType SqueegeeCleanType
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the length of time that has ellapsed since the last time
        /// the squeegee was cleaned
        /// </summary>
        public TimeSpan TimeSinceLastClean
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates how many printing cycles have been completed since the last
        /// time the squeegee was cleaned
        /// </summary>
        public int CyclesSinceLastClean
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the total number of squeegee cleaning cycles that
        /// have been performed since this squeegee was loaded.
        /// </summary>
        public int SqueegeeCleanCycles
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the total amount of time that it took to perform this squeegee clean operation
        /// </summary>
        public TimeSpan SqueegeeCleanTime
        {
            get;
            set;
        }
    }
}
