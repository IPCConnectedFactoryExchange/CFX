using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class MaterialPackageMSDData : MaterialPackageData
    {
        public DateTime? ExpirationDateTime
        {
            get;
            set;
        }

        public DateTime? OriginalExposureDateTime
        {
            get;
            set;
        }

        public DateTime? LastExposureDateTime
        {
            get;
            set;
        }


        public TimeSpan? RemainingExposureTime
        {
            get;
            set;
        }

        public MSDLevel MSDLevel
        {
            get;
            set;
        }

        public MSDState MSDState
        {
            get;
            set;
        }
    }
}
