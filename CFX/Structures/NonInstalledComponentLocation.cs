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
    /// Location of a non installed component
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NonInstalledComponentLocation
    {
        /// <summary>
        /// The location is unknown, the component is lost
        /// </summary>
        Lost,
        /// <summary>
        /// The component is back to the material carrier
        /// </summary>
        MaterialCarrier,
        /// <summary>
        /// The component has been thrown in the rejection box
        /// </summary>
        RejectionBox
    }
}
