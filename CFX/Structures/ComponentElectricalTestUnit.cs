using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Unit used for an electrical test
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentElectricalTestUnit
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// Ohm (for resistors)
        /// </summary>
        Ohm,
        /// <summary>
        /// Farad (for capacitors)
        /// </summary>
        Farad,
        /// <summary>
        /// Henry (for inductors)
        /// </summary>
        Henry,
        /// <summary>
        /// Volt (for diodes)
        /// </summary>
        Volt,
        /// <summary>
        /// Hertz
        /// </summary>
        Hertz,
        /// <summary>
        /// Watt
        /// </summary>
        Watt,
    }
}
