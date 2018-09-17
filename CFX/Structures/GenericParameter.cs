using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Structure that represents a generic named value parameter.
    /// </summary>
    public class GenericParameter : Parameter
    {
        /// <summary>
        /// The name of the parameter
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The new value for the parameter
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}
