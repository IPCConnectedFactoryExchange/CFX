using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The Side location is giving an indication for the operator from which side in transport direction of the PCB unit
    /// the fault or error can be accessed and fixed. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SideLocation
    {
        /// <summary>
        /// c
        /// </summary>
        Unknown,
        /// <summary>
        /// Location of the occurrence of the fault is the rigfht side in transport direction of the PCB unit. 
        /// </summary>
        Right,
        /// <summary>
        /// Location of the occurrence of the fault is the left side in transport direction of the PCB unit. 
        /// </summary>
        Left,
        /// <summary>
        /// Location of the occurrence of the fault are both sides in transport direction of the PCB unit. 
        /// </summary>
        Both,
    }
}
