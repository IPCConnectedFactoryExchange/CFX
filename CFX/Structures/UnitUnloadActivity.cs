using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A specialized type of Activity that occurs when a unit is unloaded from an endpoint.
    /// </summary>
    public class UnitUnloadActivity : Activity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitUnloadActivity()
        {
            ActivityName = "UNIT UNLOAD";
            ValueAddType = ValueAddType.NonValueAdd;
        }


        /// <summary>
        /// The total amount of time consumed by the load event.
        /// </summary>
        public TimeSpan UnloadTime
        {
            get;
            set;
        }
    }
}
