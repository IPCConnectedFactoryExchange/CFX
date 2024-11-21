using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Dispensing
{
  /// <summary>
  /// An enumeration indicating different types of dispensing valves that might exist at an endpoint. 
  /// If no valve is mounted on the head, the enumeration shall be set to “Undefined”.
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
    public enum DispenserValveType
    {
        /// <summary>
        /// Undefined valve type or no valve mounted on the head
        /// </summary>
        Undefined,
        /// <summary>
        /// Time-pressure valve type
        /// </summary>
        TimePressure,
        /// <summary>
        /// Auger valve type
        /// </summary>
        Auger,
        /// <summary>
        /// Piezo valve type
        /// </summary>
        Piezo,
        /// <summary>
        /// Pneumatic valve type
        /// </summary>
        Pneumatic,
        /// <summary>
        /// Volumetric valve type
        /// </summary>
        Volumetric
  }
}
