using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Response from a process endpoint to a request to obtain the setup requirements of the active recipe.
    /// The response lists the required materials and tools, along with the locations where 
    /// the materials/tools must be loaded.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "RecipeName": "RECIPE4455",
    ///   "RecipeRevision": "C",
    ///   "Lane": 1,
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   },
    ///   "SetupRequirements": {
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "STAGE1",
    ///       "StageType": "Work"
    ///     },
    ///     "SetupName": "COMMONSETUP45",
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
    public class GetRequiredSetupResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetRequiredSetupResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// Result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the recipe associated with the required setup.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// The revision of the recipe that is required (eg. "A", "B", etc.)
        /// </summary>
        public string RecipeRevision
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Lane associated with this setup.
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property designating the specific Stage associated with this setup.
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// A structure indicating the setup requirements.
        /// </summary>
        public StationSetupRequirements SetupRequirements
        {
            get;
            set;
        }
    }
}
