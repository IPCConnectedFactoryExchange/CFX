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
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CounterType
    {
        /// <summary>
        /// General sensor
        /// </summary>    
        General,
        /// <summary>
        /// Unknown sensor
        /// </summary>
        Unkwnown,
        /// <summary>
        /// Rotation axis
        /// </summary>
        RotationAxis,
        /// <summary>
        /// Head machine - time based
        /// </summary>
        HeadMaintenanceTime,
        /// <summary>
        /// Head machine - count based
        /// </summary>
        HeadMaintenanceCounter,
        /// <summary>
        /// Star axis
        /// </summary>
        StarAxis,
        /// <summary>
        /// Tape cutter number of cuts
        /// </summary>
        TapeCutterCuts,
        /// <summary>
        /// Vacuum pump filter pumps
        /// </summary>
        VacuumPumpFilter,
        /// <summary>
        /// X axis mileage
        /// </summary>
        xAxis,
        /// <summary>
        /// Y axis mileage
        /// </summary>
        yAxis,
        /// <summary>
        /// Z Axis moves
        /// </summary>
        zAxis,
        /// <summary>
        /// Vacuum pump slider pumps
        /// </summary>
        VacuumPumpSlider,
        /// <summary>
        /// Feeder Cycle count
        /// </summary>
        FeederCycleCount,
        /// <summary>
        /// Feeder Cycle count
        /// </summary>
        RotationAxisCount,
        /// <summary>
        /// Camera flash count
        /// </summary>
        CameraFlashCount,
        /// <summary>
        /// Camera count
        /// </summary>
        CameraCount
    }
}
