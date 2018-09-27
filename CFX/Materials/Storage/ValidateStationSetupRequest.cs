using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Request to a process endpoint to validate that the currently loaded materials
    /// comply with the setup requirements supplied in this request.
    /// <code language="none">
    /// {
    ///   "SetupRequirements": {
    ///     "Lane": null,
    ///     "Stage": null,
    ///     "SetupName": "COMMONSETUP1",
    ///     "MaterialSetupRequirements": [
    ///       {
    ///         "Position": "B1.F.45",
    ///         "PartNumber": "IPN1123",
    ///         "ApprovedAlternateParts": [
    ///           "IPN2343",
    ///           "IPN3432"
    ///         ],
    ///         "ApprovedManufacturerParts": [
    ///           "MOT4329",
    ///           "SAM5566"
    ///         ]
    ///       },
    ///       {
    ///         "Position": "B1.F.47",
    ///         "PartNumber": "IPN1124",
    ///         "ApprovedAlternateParts": [
    ///           "IPN3344",
    ///           "IPN3376"
    ///         ],
    ///         "ApprovedManufacturerParts": [
    ///           "JP55443",
    ///           "TX554323"
    ///         ]
    ///       }
    ///     ],
    ///     "ToolSetupRequirements": [
    ///       {
    ///         "Position": "MODULE1.BEAM1",
    ///         "PartNumber": "HEADTYPE5566",
    ///         "ToolIdentifier": null
    ///       },
    ///       {
    ///         "Position": "MODULE1.BEAM2",
    ///         "PartNumber": "HEADTYPE5577",
    ///         "ToolIdentifier": null
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class ValidateStationSetupRequest : CFXMessage
    {
        /// <summary>
        /// The setup requirements to be validated
        /// </summary>
        public StationSetupRequirements SetupRequirements
        {
            get;
            set;
        }
    }
}
