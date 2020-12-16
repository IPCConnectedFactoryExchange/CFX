using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the sampling strategy to be employed on a particular lot of material / units during test or inspection
    /// </summary>
    public class SamplingInformation
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SamplingInformation()
        {
            SamplingMethod = SamplingMethod.NoSampling;
        }

        /// <summary>
        /// An enumeration describing the sampling method that was employed (if any)
        /// </summary>
        public SamplingMethod SamplingMethod
        {
            get;
            set;
        }

        /// <summary>
        /// The total number of units in the lot
        /// </summary>
        public double? LotSize
        {
            get;
            set;
        }

        /// <summary>
        /// The number of units from the total lot to be inspected / tested.  
        /// This is a subset of the total lot.
        /// </summary>
        public double? SampleSize
        {
            get;
            set;
        }
    }
}
