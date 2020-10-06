using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of calibrations
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CalibrationType
    {
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
        /// T.B.D.
        /// </summary>
        BoardCamera,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        FeedUnitsTable,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        NozzleChanger,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        BoardReferenceCorner,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        ComponentSensorCamera,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        SegmentOffset,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        ComponentSensorLightBarrier,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        ZeroPressure,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        BoardMapping,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        HeadMapping,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        HeadsAndCameras,
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// T.B.D.
        /// </summary>
        VacuumTooling

    }
}
