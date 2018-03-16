using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Reasons why a unit is blocked
    /// </summary>
    public enum BlockReason
    {
        /// <summary>
        /// No reason specified
        /// </summary>
        Unspecified,
        /// <summary>
        /// There exists suspicion that the unit may be defective or otherwise problematic
        /// </summary>
        SuspectedProblem,
        /// <summary>
        /// The unit is known to be defective.
        /// </summary>
        Defective,
    }
}
