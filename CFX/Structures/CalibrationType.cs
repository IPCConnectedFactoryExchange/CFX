using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Types of calibrations
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CalibrationType
    {
        /// <summary>
        /// Unknown calibration type
        /// </summary>
        Unkwnown,
        /// <summary>
        /// Specified when the calibration cannot be characterized by one of the other
        /// options of this enumeration
        /// </summary>
        General,
        /// <summary>
        /// The X Axis of a robotic / automated device has been calibrated
        /// </summary>
        XAxis,
        /// <summary>
        /// The Y Axis of a robotic / automated device has been calibrated
        /// </summary>
        YAxis,
        /// <summary>
        /// The Z Axis of a robotic / automated device has been calibrated
        /// </summary>
        ZAxis,
        /// <summary>
        /// The robotic / automated device has calibrated the location of a 
        /// production unit (typically using reference/fiducial marks, but also
        /// potentially by other means)
        /// </summary>
        UnitPosition,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The robotic / automated device has calibrated the travel range
        /// of a part (typically head)
        /// </summary>
        TravelRange,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The robotic / automated device has calibrated the identification system
        /// </summary>
        SystemIdentification,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// The robotic / automated device has calibrated the zero reference position
        /// </summary>
        ZeroPointOffset,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Camera reading the board
        /// </summary>
        BoardCamera,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Unit feed table
        /// </summary>
        FeedUnitsTable,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Changer of the nozzle
        /// </summary>
        NozzleChanger,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Corner reference for the vboard
        /// </summary>
        BoardReferenceCorner,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Component sensor camera
        /// </summary>
        ComponentSensorCamera,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Offset
        /// </summary>
        SegmentOffset,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Barrier for the light sensor
        /// </summary>
        ComponentSensorLightBarrier,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Pressure
        /// </summary>
        ZeroPressure,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Mapping of the board 
        /// </summary>
        BoardMapping,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Mapping of the head
        /// </summary>
        HeadMapping,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Head and camera
        /// </summary>
        HeadsAndCameras,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Vacuum tool
        /// </summary>
        VacuumTooling,
        /// <summary>
        /// Dispensing valve
        /// </summary>
        DispensingValve
    }
}
