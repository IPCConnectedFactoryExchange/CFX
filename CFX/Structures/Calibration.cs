using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// A dynamic structure describing a calibration event.
    /// </summary>
    public class Calibration
    {
        /// <summary>
        /// A vendor-specific string based code identifying the specific calibration performed
        /// </summary>
        public string CalibrationCode
        {
            get;
            set;
        }
        
        /// <summary>
        /// An enumeration indicated the type of calibration that was performed
        /// </summary>
        public CalibrationType CalibrationType
        {
            get;
            set;
        }

        /// <summary>
        /// Free form comments related to this particular calibration
        /// </summary>
        public string Comments
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Describes the status of the calibration that was performed (e.g. Undefined, Failed, Ok)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public OperationStatus? Status
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Optional, when the calibration was performed
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public DateTime? CalibrationTime
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// A list of measurements taken during calibration
        /// </summary>
        public List<CalibrationMeasurement> Measurements
        {
            get;
            set;
        }
    }
}
