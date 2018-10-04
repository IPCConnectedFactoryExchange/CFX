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
    }
}
