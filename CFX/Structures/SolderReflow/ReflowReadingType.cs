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
    /// An enumeration indicating the type of a setpoint within a particular area of a reflow zone.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReflowReadingType
    {
        /// <summary>
        /// The reading a temperature reading, expressed in degrees celcius (C).
        /// </summary>
        Temperature,
        /// <summary>
        /// The reading is an oxygen reading, expressed in parts per million (PPM).
        /// </summary>
        O2,
        /// <summary>
        /// The reading is an power reading, expressed in watts (w).
        /// </summary>
        Power,
        /// <summary>
        /// The reading is an power level reading, expressed as a percentage from 0.0 to 100.0 (%).
        /// </summary>
        PowerLevel,
        /// <summary>
        /// The reading is a vacuum reading, expressed in Pascals (Pa).
        /// </summary>
        Vacuum,
        /// <summary>
        /// The reading is a vacuum reading, expressed in seconds (s).
        /// </summary>
        VacuumHoldTime,
        /// <summary>
        /// A measure of the amount of relative convection, expressed in Pascals (Pa).
        /// </summary>
        ConvectionRate,
    }
}
