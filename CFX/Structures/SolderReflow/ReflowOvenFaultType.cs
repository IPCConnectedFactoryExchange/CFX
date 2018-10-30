using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderReflow
{
    /// <summary>
    /// An enumeration that defines the different types of faults that might occur on a solder reflow oven.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReflowOvenFaultType
    {
        /// <summary>
        /// The conveyor is moving too slowly. 
        /// </summary>
        LowBeltSpeed,
        /// <summary>
        /// The conveyor is moving too quickly.
        /// </summary>
        HighBeltSpeed,
    }
}
