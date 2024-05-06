using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.InformationSystem.TopicValidation
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Example 1: Tools
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Tools",
    ///   "ValidationTopicData": {
    ///     "ValidationTopicData": [
    ///       {
    ///         "UniqueIdentifier": "T00001",
    ///         "Name": "Tool 1"
    ///       },
    ///       {
    ///         "UniqueIdentifier": "T00002",
    ///         "Name": "Tool 2"
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// Example 2: Materials
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Materials",
    ///   "ValidationTopicData": {
    ///     "ValidationTopicData": [
    ///       {
    ///         "ResourceLocation": null,
    ///         "LocationIdentifier": "5555646454",
    ///         "LocationName": "SLOT44",
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": "MAT4566554543",
    ///           "InternalPartNumber": "IPN48899",
    ///           "InternalPackageName": null,
    ///           "Quantity": 748.0,
    ///           "LeadingMaterialPackage": null,
    ///           "BatchId": null,
    ///           "BatchMaterialPackage": null,
    ///           "GreyZone": 0.0
    ///         },
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "123334",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 8.0,
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334",
    ///           "ParentCarrier": null
    ///         }
    ///       },
    ///       {
    ///         "ResourceLocation": null,
    ///         "LocationIdentifier": "5555646455",
    ///         "LocationName": "SLOT45",
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": "MAT4566553421",
    ///           "InternalPartNumber": "IPN45577",
    ///           "InternalPackageName": null,
    ///           "Quantity": 151.0,
    ///           "LeadingMaterialPackage": null,
    ///           "BatchId": null,
    ///           "BatchMaterialPackage": null,
    ///           "GreyZone": 0.0
    ///         },
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "123335",
    ///           "BaseName": "MULTILANEFEEDER123335",
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 4.0,
    ///           "UniqueIdentifier": "1233335A",
    ///           "Name": "TAPEFEEDER8mm1233335A",
    ///           "ParentCarrier": null
    ///         }
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// Example 3: MaterialCarrier
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "MaterialCarrier",
    ///   "ValidationTopicData": {
    ///     "ValidationTopicData": [
    ///       {
    ///         "ResourceLocation": null,
    ///         "LocationIdentifier": "UID384234893",
    ///         "LocationName": "SLOT45",
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "123334",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 8.0,
    ///           "UniqueIdentifier": "1233334",
    ///           "Name": "TAPEFEEDER8mm1233334",
    ///           "ParentCarrier": null
    ///         }
    ///       },
    ///       {
    ///         "ResourceLocation": null,
    ///         "LocationIdentifier": "UID384234000",
    ///         "LocationName": "SLOT44",
    ///         "CarrierInformation": {
    ///           "UniqueIdentifier": "1233333",
    ///           "Name": null,
    ///           "ParentCarrier": null
    ///         }
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    ///Example 4: Recipe
    /// <code language="none">
    /// {
    ///   "ValidationTopic": "Recipe",
    ///   "ValidationTopicData": {
    ///     "RecipeName": "Recipe 1",
    ///     "Revision": "2.0",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "Stage1",
    ///       "StageType": "Work"
    ///     }
    ///   }
    /// }
    /// </code>
    /// Request that a specific topic needs to be validated before continuing the process / operations.

    /// </summary>
    [Utilities.CreatedVersion("2.0")]
    public class ValidateTopicRequest : CFXMessage
    {
        /// <summary>
        /// An enum for the specific validation topic of the request.
        /// </summary>
        public ValidationTopic ValidationTopic
        {
            get;
            set;
        }
        /// <summary>
        /// A structure which defines the ValidationTopicData fo the request
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public ValidationData ValidationTopicData
        {  get; set; }
    }
}