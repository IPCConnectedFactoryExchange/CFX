using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is loaded into an endpoint.
    /// </summary>
    public class UnitLoadActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitLoadActivity()
        {
            ActivityName = "UNIT LOAD";
            ValueAddType = ValueAddType.NonValueAdd;
        }


        /// <summary>
        /// The total amount of time consumed by the load event.
        /// </summary>
        public TimeSpan LoadTime
        {
            get;
            set;
        }
    }
}
