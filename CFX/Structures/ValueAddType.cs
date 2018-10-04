using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// An enumeration describing the value-add nature of an activity or process.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValueAddType
    {
        /// <summary>
        /// The activity or process directly contributed to the process of creating one or more production unit(s), and
        /// the units left the activity or process differently than when they arrived.
        /// </summary>
        RealValueAdd,
        /// <summary>
        /// The activity or process had business value, but did not directly effect the production units, such as
        /// in the case of an inspection or testing process.
        /// </summary>
        BusinessValueAdd,
        /// <summary>
        /// The activity or process is necessary, but does not add any value.  For example, a tool change on a pick and place
        /// machine.
        /// </summary>
        NonValueAdd
    }
}
