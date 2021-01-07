using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// This message is used to request a process endpoint for the details of a named
    /// recipe. The response includes details of the recipe, depending on the 
    /// classification of the process.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "Recipe": {
    ///     "Name": "RECIPE4455",
    ///     "Revision": null,
    ///     "MimeType": "application/octet-stream",
    ///     "RecipeData": "ESKImSNVZlM="
    ///   }
    /// }
    /// </code>
    /// <para>UnitsInspectionRecipe provides the means to convey static recipe information of
    /// inspection programs. It is expected to contain an InspectionMeasurementExpected object
    /// for each solder deposit to inspect.
    /// </para>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "Recipe": {
    ///     "$type": "CFX.Structures.SolderPasteInspection.SolderPasteInspectionRecipe, CFX",
    ///     "Name": "SolderRecipeXYZ_TextBoard1",
    ///     "Revision": "1.3.3.33",
    ///     "ExpectedCycleTime": 0.0,
    ///     "ExpectedUnitsPerWorkTransaction": 0.0,
    ///     "UnitLength": null,
    ///     "UnitWidth": null,
    ///     "UnitHeight": null,
    ///     "MimeType": null,
    ///     "RecipeData": null,
    ///     "UnitsToInspect": [
    ///       {
    ///         "UnitPositionNumber": 1,
    ///         "Name": null,
    ///         "ChildObjects": [
    ///           {
    ///             "Group": "Resistor",
    ///             "Type": "Pad",
    ///             "RefNo": 1,
    ///             "CRD": "R100.1",
    ///             "PartNumber": "A2C000628080001",
    ///             "PackageType": "0201",
    ///             "Steps": [
    ///               {
    ///                 "Name": "PasteDeposit",
    ///                 "Sequence": 1,
    ///                 "TargetValue": {
    ///                   "EX": 0.8,
    ///                   "EY": 1.5,
    ///                   "EZ": 0.1,
    ///                   "PX": 1000.0,
    ///                   "PY": 1200.0,
    ///                   "EA": 1.2,
    ///                   "EVol": 0.0001,
    ///                   "AR": 1.8,
    ///                   "RXY": 0.0,
    ///                   "Vertices": null,
    ///                   "UniqueIdentifier": "249a0c81-875f-474f-85b3-5c628108efec",
    ///                   "MeasurementName": null,
    ///                   "TimeRecorded": null,
    ///                   "Sequence": 0,
    ///                   "Result": "Passed",
    ///                   "CRDs": null
    ///                 }
    ///               }
    ///             ]
    ///           },
    ///           {
    ///             "Group": "Resistor",
    ///             "Type": "Pad",
    ///             "RefNo": 2,
    ///             "CRD": "R100.2",
    ///             "PartNumber": "A2C000628080001",
    ///             "PackageType": "0201",
    ///             "Steps": [
    ///               {
    ///                 "Name": "PasteDeposit",
    ///                 "Sequence": 1,
    ///                 "TargetValue": {
    ///                   "EX": 0.8,
    ///                   "EY": 1.5,
    ///                   "EZ": 0.0,
    ///                   "PX": 3000.0,
    ///                   "PY": 1200.0,
    ///                   "EA": 1.2,
    ///                   "EVol": 0.0001,
    ///                   "AR": 1.8,
    ///                   "RXY": 0.0,
    ///                   "Vertices": null,
    ///                   "UniqueIdentifier": "71aeb946-ace8-4c83-997e-2bc9cabc5e91",
    ///                   "MeasurementName": null,
    ///                   "TimeRecorded": null,
    ///                   "Sequence": 0,
    ///                   "Result": "Passed",
    ///                   "CRDs": null
    ///                 }
    ///               }
    ///             ]
    ///           }
    ///         ]
    ///       }
    ///     ],
    ///     "RecipeGenerationDate": "2020-11-30T13:35:00.4214651+01:00",
    ///     "InspectionMethod": "Human"
    ///   }
    /// }
    /// </code>
    /// </summary>

    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetRecipeResponse : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GetRecipeResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The recipe.  This is a dynamic structure tha supports specialized recipe types 
        /// for different types of equipment.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Recipe Recipe
        {
            get;
            set;
        }
    }
}
