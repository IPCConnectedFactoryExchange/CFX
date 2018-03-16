using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Levels of Moisture Sensitivity (for electronic devices)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MSDLevel
    {
        /// <summary>
        /// Unknown sensitivity
        /// </summary>
        Unspecified,
        /// <summary>
        /// Sensitivity Level 1
        /// </summary>
        MSL1,
        /// <summary>
        /// Sensitivity Level 1
        /// </summary>
        MSL2,
        /// <summary>
        /// Sensitivity Level 2
        /// </summary>
        MSL2A,
        /// <summary>
        /// Sensitivity Level 2A
        /// </summary>
        MSL3,
        /// <summary>
        /// Sensitivity Level 3
        /// </summary>
        MSL4,
        /// <summary>
        /// Sensitivity Level 4
        /// </summary>
        MSL5,
        /// <summary>
        /// Sensitivity Level 5
        /// </summary>
        MSL5A,
        /// <summary>
        /// Sensitivity Level 6
        /// </summary>
        MSL6
    }
}
