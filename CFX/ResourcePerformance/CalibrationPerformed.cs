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
    ///   "Calibration": {
    ///     "CalibrationCode": "FID1",
    ///     "CalibrationType": "UnitPosition",
    ///     "Comments": "Position Check.  Fiducial FID1."
    ///     "Status": "Ok"
    ///     "CalibrationTime": null
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
