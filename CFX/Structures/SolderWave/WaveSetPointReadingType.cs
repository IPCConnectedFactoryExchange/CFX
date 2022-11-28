using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// An enumeration indicating the type of a setpoint within a particular area of a wave soldering machine.
    /// </summary>
    /// <remarks>The <seealso cref="WaveSetPointReadingType"/> will be used in <seealso cref="WaveSetPoint"/> and <seealso cref="WaveReading"/>.</remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaveSetPointReadingType
    {
        /// <summary>
        /// The temperature, expressed in degrees celcius (C).
        /// </summary>
        Temperature,
        /// <summary>
        /// The oxygen, expressed in parts per million (PPM).
        /// </summary>
        O2,
        /// <summary>
        /// The Amount, expected in milliliter per solder frame or pcba.
        /// </summary>
        AmountOfLiquid,
        /// <summary>
        /// The speed, expected in centimeters per minute (cm/min).
        /// </summary>
        Speed,
        /// <summary>
        /// The power, expressed in watts (W).
        /// </summary>
        Power,
        /// <summary>
        /// The power level, expressed as a percentage from 0.0 to 100.0 (%).
        /// </summary>
        PowerLevel,
        /// <summary>
        /// A measure of the amount of relative convection, expressed in Pascals (Pa).
        /// </summary>
        ConvectionRate,
        /// <summary>
        /// The rotationspeed in rotations per minute (rpm).
        /// </summary>
        RotationalSpeed,
        /// <summary>
        /// The distance beween the solder wave nozzle and the lower side of the solder frame or pcba in millimeter (mm).
        /// </summary>
        Clearance,
        /// <summary>
        /// The speed of a fluxer head in millimeters per second mm/s.
        /// </summary>
        Velocity,
        /// <summary>
        /// The angle of the conveyor above the soldering nozzle in degrees (°).
        /// </summary>
        SolderAngle,
        /// <summary>
        /// A period of time or a time itself, expressed in seconds (s).
        /// </summary>
        Duration,
    }
}
