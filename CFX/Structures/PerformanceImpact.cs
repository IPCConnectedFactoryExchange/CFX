using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// Performance impacts of a machine (i.e., in case of lower-than-expected performance)
    /// It shall be "null" or not sent at all if the machine doesn't support the PerformanceImpact attribute.
    /// An empty list indicates that the machine is running at "best-performance"
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    public class PerformanceImpact
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PerformanceImpact()
        {
            
        }
        /// <summary>
        /// The cause of this performance impact.
        /// </summary>
        public PerformanceImpactCause Cause
        {
            get;
            set;
        }
    }
}
