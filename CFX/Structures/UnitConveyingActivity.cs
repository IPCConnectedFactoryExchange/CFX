using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is conveyed in an endpoint.
    /// </summary>
    public class UnitConveyingActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitConveyingActivity()
        {
            ActivityName = "UNIT CONVEYING";
            ValueAddType = ValueAddType.NonValueAdd;
        }

        /// <summary>
        /// The total distance of conveying (in mm)
        /// </summary>
        public float ConveyingDistance
        {
            get;
            set;
        }

        /// <summary>
        /// The Stage from where the unit is conveyed
        /// </summary>
        public Stage DepartureStage
        {
            get;
            set;
        }

        /// <summary>
        /// The Stage to where the unit is conveyed
        /// </summary>
        public Stage ArrivalStage
        {
            get;
            set;
        }
    }
}
