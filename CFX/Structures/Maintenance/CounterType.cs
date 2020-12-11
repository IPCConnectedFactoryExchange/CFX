using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;



namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// An enumeration indicating the type of counter that is capture by the Endpoint and its resources / sensors
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CounterType
    {
        /// <summary>
        /// Unknown counter
        /// </summary>
        Unkwnown,
        /// <summary>
        /// General counter
        /// </summary>    
        General,
        ///<summary>
        /// Non standard counter.
        /// It shall be used in combination with the CustomCounterType field
        /// </summary>
        NonStandard,
        /// <summary>
        /// Rotation, mileage measured by a sensor
        /// </summary>
        Odometer,
        /// <summary>
        /// Time based sensor, in hour
        /// </summary>
        Timer,
        /// <summary>
        /// Counter for the sensor specified by the name and position
        /// It can be, among the others: cuts, flashes, pumps, picking components, placed components, rotations
        /// </summary>
        ActivityCount
    }
}
