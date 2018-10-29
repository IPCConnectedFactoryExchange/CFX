using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a planar, 2 dimensional region as defined by a series of X, Y coordinates
    /// that when plotted, form the region.
    /// </summary>
    public class Region
    {
        public Region()
        {
            RegionSegments = new List<Segment>();
        }

        /// <summary>
        /// X coordinate of first point in region outline
        /// </summary>
        public double StartPointX
        {
            get;
            set;
        }

        /// <summary>
        /// Y coordinate of first point in region outline
        /// </summary>
        public double StartPointY
        {
            get;
            set;
        }

        /// <summary>
        /// Collection of (X, Y) coordinates that when plotted form a planar region.
        /// </summary>
        public List<Segment> RegionSegments
        {
            get;
            set;
        }
    }
}
