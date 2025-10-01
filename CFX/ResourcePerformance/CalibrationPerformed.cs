using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent when calibration of any sort has been performed at an endpoint.
    /// <code language="none">
    /// {
    ///   "TransactionID": "a71dae78-b78d-49b6-939d-d8fb20281391",
    ///   "Calibration": {
    ///     "CalibrationCode": "FID1",
    ///     "CalibrationType": "UnitPosition",
    ///     "Comments": "Position Check.  Fiducial FID1.",
    ///     "Status": "Ok",
    ///     "CalibrationTime": null,
    ///     "Measurements": [
    ///       {
    ///         "MeasurementName": "Measure1",
    ///         "MeasurementValue": {
    ///           "Value": 0.97,
    ///           "ValueUnits": "mm",
    ///           "ExpectedValue": 1.0,
    ///           "ExpectedValueUnits": "mm",
    ///           "MinimumAcceptableValue": 0.9,
    ///           "MinimumAcceptableValueUnits": "mm",
    ///           "MaximumAcceptableValue": 1.2,
    ///           "MaximumAcceptableValueUnits": "mm"
    ///         }
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CalibrationPerformed : CFXMessage
    {
        /// <summary>
        /// A dynamic structure describing the calibration that was performed.
        /// The structure may varty depending on the native of the calibration.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Calibration Calibration
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Optional: The id of the work transaction with which this calibration is associated.
        /// Empty if calibration not associated with a work transaction.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public Guid? TransactionID
        {
            get;
            set;
        }
    }
}
