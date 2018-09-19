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
    public enum ReflowSetpointType
    {
        /// <summary>
        /// The setpoint is a temperature setpoint, expressed in degrees celcius (C).
        /// </summary>
        Temperature,
        /// <summary>
        /// The setpoint is an oxygen setpoint, expressed in parts per million (PPM).
        /// </summary>
        O2,
        /// <summary>
        /// The setpoint is a vacuum setpoint, expressed in Pascals (Pa).
        /// </summary>
        Vacuum,
        /// <summary>
        /// The setpoint is a vacuum setpoint, expressed in seconds (s).
        /// </summary>
        VacuumHoldTime,
    }
}
