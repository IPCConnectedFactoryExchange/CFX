using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// An enumeration indicating different types of sleep states that might exist at an endpoint.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SleepType
    {
        /// <summary>
        /// Station/Stage is fully on with no power saving
        /// </summary>
        Awake,
        /// <summary>
        /// Station/Stage is in standby with minimal power saving
        /// </summary>
        Shallow,
        /// <summary>
        /// Station/Stage is in standby with medium power saving
        /// </summary>
        Sleep,
        /// <summary>
        /// Station/Stage is in standby with maximum power saving
        /// </summary>
        Hybernate
    }
}