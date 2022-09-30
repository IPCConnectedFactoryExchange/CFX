using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// Performance impacts of a machine (i.e., in case of lower-than-expected performance) 
    /// </summary>
    public class PerformanceImpact
    {
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
