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
    ///   "Lane": "1",
    ///   "Stage": "1",
    ///   "SetupRequirements": {
    ///     "Lane": "1",
    ///     "Stage": "1",
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
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class GetRequiredSetupResponse : CFXMessage
    {
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

        public StationSetupRequirements SetupRequirements
        {
            get;
            set;
        }
    }
}
