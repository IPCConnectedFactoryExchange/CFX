using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Region
    {
        public Region()
        {
            RegionSegments = new List<Segment>();
        }

        public double StartPointX
        {
            get;
            set;
        }

        public double StartPointY
        {
            get;
            set;
        }

        public List<Segment> RegionSegments
        {
            get;
            set;
        }
    }
}
