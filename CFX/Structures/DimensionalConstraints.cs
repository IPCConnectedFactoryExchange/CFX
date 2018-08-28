using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the maximum and mininum dimensions and weight that a production unit is permitted
    /// to be in order to be processed at a particular endpoint.
    /// </summary>
    public class DimensionalConstraints
    {
        /// <summary>
        /// The minimum dimension that a unit may be in the X axis,
        /// that is in the direction of flow of the conveyor.  Expressed in mm.
        /// </summary>
        public double MinimumLength
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum dimension that a unit may be in the X axis,
        /// that is in the direction of flow of the conveyor.  Expressed in mm.
        /// </summary>
        public double MaximumLength
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum dimension that a unit may be in the Y axis,
        /// that is perpendicular to the direction of flow of the conveyor. Expressed in mm.
        /// </summary>
        public double MinimumWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum dimension that a unit may be in the Y axis,
        /// that is perpendicular to the direction of flow of the conveyor. Expressed in mm.
        /// </summary>
        public double MaximumWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum height (Z dimension) that a unit may be to be processed by this endpoint.
        /// Expressed in mm.
        /// </summary>
        public double MinimumHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum height (Z dimension) that a unit may be to be processed by this endpoint.
        /// Expressed in mm.
        /// </summary>
        public double MaximumHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum weight that a unit may be to be processed by this endpoint.
        /// Expressed in grams.
        /// </summary>
        public double MinimumWeight
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum weight that a unit may be to be processed by this endpoint.
        /// Expressed in grams.
        /// </summary>
        public double MaximumWeight
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum thickness that a unit may be to be processed by this endpoint.
        /// Expressed in mm.
        /// </summary>
        public double MinimumThickness
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum thickness that a unit may be to be processed by this endpoint.
        /// Expressed in mm.
        /// </summary>
        public double MaximumThickness
        {
            get;
            set;
        }
    }
}
