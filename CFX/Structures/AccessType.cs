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
    /// The Access Type is giving an indication for the line engineer if the fault, error or warning messages in the fault object
    /// can be handled via a remote terminal session to the equipment
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessType
    {
        /// <summary>
        /// Access Type for this fault is unknown 
        /// </summary>
        Unknown,
        /// <summary>
        /// Ignore Assist access type. This is typically an assist which is shown on the station GUI when the operator is working
        /// physically on the machine. These Assists can be ignored by the external system. They are sent anyways exterbal system
        /// can decide to redefine the access type to local or remote. 
        /// </summary>
        Ignore,
        /// <summary>
        /// Local assist (somebody needs to go physically to the location) 
        /// </summary>
        Local,
        /// <summary>
        /// Remote assist (issue can be resolved by remote terminal session on the station GUI) 
        /// </summary>
        Remote,
    }
}
