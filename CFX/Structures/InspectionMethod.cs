using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Method of testing
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InspectionMethod
    {
        /// <summary>
        /// The inspection was performed by a human being
        /// </summary>
        Human,
        /// <summary>
        /// The inspection was performed by automated optical inspection equipment / device
        /// </summary>
        AOI,
        /// <summary>
        /// The inspection was performed by automated solder paste inspection equipment / device
        /// </summary>
        SPI,
        /// <summary>
        /// The test was performed by an automated X-Ray inspection machine
        /// </summary>
        AXI
    }
}
