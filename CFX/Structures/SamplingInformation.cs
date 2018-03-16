using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class SamplingInformation
    {
        public SamplingInformation()
        {
            SamplingMethod = SamplingMethod.NoSampling;
        }

        public SamplingMethod SamplingMethod
        {
            get;
            set;
        }

        public double? LotSize
        {
            get;
            set;
        }

        public double? SampleSize
        {
            get;
            set;
        }
    }
}
