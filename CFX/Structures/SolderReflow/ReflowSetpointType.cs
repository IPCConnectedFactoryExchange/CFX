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
        /// The setpoint is a temperature setpoint, expressed in degrees Celcius (C).
        /// </summary>
        Temperature,
        /// <summary>
        /// The setpoint is an oxygen setpoint, expressed in parts per million (ppm).
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
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// Hold Time, expressed in seconds (s).
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        HoldTime,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// The setpoint is a power level reading, expressed as a percentage from 0.0 to 100.0 (%).
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        PowerLevel,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// The setpoint is a Numerical Level.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        Level,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// The setpoint is a Position, expressed in millimeter (mm).
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        Position,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// The setpoint is a temperature slope, expressed in Kelvin per second (K/s).
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        Slope


    }
}
