using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// An enumeration indicating the type of cleaning reading
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CleaningReadingType
    {
        /// <summary>
        /// Bottom spray bars pressure reading, expressed in Pascals (Pa)
        /// </summary>
        BottomSprayBarsPressure,
        /// <summary>
        /// Bottom water knife pressure reading, expressed in Pascals (Pa)
        /// </summary>
        BottomWaterKnifePressure,
        /// <summary>
        /// min concentration reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>
        ConcentrationMin,
        /// <summary>
        /// max concentration reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>    
        ConcentrationMax,
        /// <summary>
        /// average concentration reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>
        ConcentrationAverage,
        /// <summary>
        /// min conductivity reading, expressed in (uS/cm)
        /// </summary>
        ConductivityMin,
        /// <summary>
        /// max conductivity reading, expressed in (uS/cm)
        /// </summary>
        ConductivityMax,
        /// <summary>
        /// average conductivity reading, expressed in (uS/cm)
        /// </summary>
        ConductivityAverage,
        /// <summary>
        /// min flow rate reading, expressed in liter per second (l/s)
        /// </summary>
        FlowRateMin,
        /// <summary>
        /// max flow rate reading, expressed in liter per second (l/s)
        /// </summary>
        FlowRateMax,
        /// <summary>
        /// average flow rate reading, expressed in liter per second (l/s)
        /// </summary>
        FlowRateAverage,
        /// <summary>
        /// min liquid conductivity reading, expressed in (uS/cm)
        /// </summary>
        LiquidConductivityMin,
        /// <summary>
        /// max liquid conductivity reading, expressed in (uS/cm)
        /// </summary>
        LiquidConductivityMax,
        /// <summary>
        /// average liquid conductivity reading, expressed in (uS/cm)
        /// </summary>
        LiquidConductivityAverage,
        /// <summary>
        /// min liquid saturation reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>
        LiquidSaturationMin,
        /// <summary>
        /// max liquid saturation reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>
        LiquidSaturationMax,
        /// <summary>
        /// average liquid saturation reading, as a percentage from 0.0 to 100.0 (%)
        /// </summary>
        LiquidSaturationAverage,
        /// <summary>
        /// min liquid pressure reading, expressed in Pascals (Pa)
        /// </summary>
        PressureMin,
        /// <summary>
        /// max liquid pressure reading, expressed in Pascals (Pa)
        /// </summary>
        PressureMax,
        /// <summary>
        /// average liquid pressure reading, expressed in Pascals (Pa)
        /// </summary>
        PressureAverage,
        /// <summary>
        /// amount of refresh water, expressed in liter (l)
        /// </summary>
        RefreshWaterAmount,
        /// <summary>
        /// min temperature reading, expressed in degrees Celsius (C)
        /// </summary>
        TemperatureMin,
        /// <summary>
        /// max temperature reading, expressed in degrees Celsius (C)
        /// </summary>
        TemperatureMax,
        /// <summary>
        /// average temperature reading, expressed in degrees Celsius (C)
        /// </summary>
        TemperatureAverage,
        /// <summary>
        /// Top spray bars pressure reading, expressed in Pascals (Pa)
        /// </summary>
        TopSprayBarsPressure,
        /// <summary>
        /// Top water knife pressure reading, expressed in Pascals (Pa)
        /// </summary>
        TopWaterKnifePressure,
        /// <summary>
        /// min ultrasonic power reading, expressed in Watt (W)
        /// </summary>
        UltrasonicPowerMin,
        /// <summary>
        /// max ultrasonic power reading, expressed in Watt (W) 
        /// </summary>
        UltrasonicPowerMax,
        /// <summary>
        /// average ultrasonic power reading, expressed in Watt (W)
        /// </summary>
        UltrasonicPowerAverage,
        /// <summary>
        /// vacuum reading, expressed in Pascals (Pa)
        /// </summary>
        Vacuum
    }
}
