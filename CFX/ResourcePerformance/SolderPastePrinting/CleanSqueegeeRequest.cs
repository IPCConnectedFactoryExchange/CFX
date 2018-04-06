using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SolderPastePrinting;

namespace CFX.ResourcePerformance.SolderPastePrinting
{
    /// <summary>
    /// Allows an external source to direct a request to a stencil printer
    /// to perform a squeegee clean operation
    /// <code language="none">
    /// {
    ///   "CleanTypeRequested": "Deep"
    /// }
    /// </code>
    /// </summary>
    public class CleanSqueegeeRequest : CFXMessage
    {
        /// <summary>
        /// An enumeration indicating the type of clean operation that is
        /// being requested
        /// </summary>
        public SMTSqueegeeCleanType CleanTypeRequested
        {
            get;
            set;
        }
    }
}
