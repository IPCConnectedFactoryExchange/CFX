using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Cleaning step of the cleaning process
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class CleaningStep
    {
        /// <summary>
        /// Cleaning step type
        /// </summary>
        public CleaningStepType CleaningStepType
        {
            get;
            set;
        }
        /// <summary>
        /// Elapsed time for cleaning step expressed in seconds (s)
        /// </summary>
        public double CleaningStepTime
        {
            get;
            set;
        }
        /// <summary>
        /// A list of readings / measurements that have been taken for this cleaning step
        /// </summary>
        public List<CleaningReading> Readings
        {
            get;
            set;
        }

    }
}
