using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production.Application
{
    /// <summary>
    /// Sent when material is applied to a production unit, such as glue, adhesives, coatings, solder, paste, etc.
    /// <code language="none">
    /// {
    ///   "TransactionId": "ce68a27a-af0b-42c2-a4b3-1066196a9f4a",
    ///   "AppliedMaterials": [
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityInstalled": 3.57,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": []
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityInstalled": 3.45,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": []
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// <para>Example 2: Applied Material structure</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "8c4560cc-c6ed-479c-ae7b-66271d4c9afc",
    ///   "AppliedMaterials": [
    ///     {
    ///       "$type": "CFX.Structures.AppliedMaterial, CFX",
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 1,
    ///       "QuantityInstalled": 0.0,
    ///       "QuantityNonInstalled": 0.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "InternalPackageName": null,
    ///         "Quantity": 887.0,
    ///         "LeadingMaterialPackage": null,
    ///         "BatchId": null,
    ///         "BatchMaterialPackage": null,
    ///         "GreyZone": 0.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": [],
    ///       "NonInstalledComponents": [],
    ///       "ReferencePartNumber": null,
    ///       "QuantityApplied": {
    ///         "Value": 3.57,
    ///         "ValueUnits": "gramm",
    ///         "ExpectedValue": 3.6,
    ///         "ExpectedValueUnits": "g",
    ///         "MinimumAcceptableValue": 3.4,
    ///         "MaximumAcceptableValue": 3.8
    ///       }
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.AppliedMaterial, CFX",
    ///       "UnitIdentifier": "PANEL23423432",
    ///       "UnitPositionNumber": 2,
    ///       "QuantityInstalled": 0.0,
    ///       "QuantityNonInstalled": 0.0,
    ///       "Material": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "InternalPackageName": null,
    ///         "Quantity": 887.0,
    ///         "LeadingMaterialPackage": null,
    ///         "BatchId": null,
    ///         "BatchMaterialPackage": null,
    ///         "GreyZone": 0.0
    ///       },
    ///       "CarrierLocation": null,
    ///       "InstalledComponents": [],
    ///       "NonInstalledComponents": [],
    ///       "ReferencePartNumber": null,
    ///       "QuantityApplied": {
    ///         "Value": 3.45,
    ///         "ValueUnits": "gramm",
    ///         "ExpectedValue": 3.6,
    ///         "ExpectedValueUnits": "g",
    ///         "MinimumAcceptableValue": 3.4,
    ///         "MaximumAcceptableValue": 3.8
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsApplied : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialsApplied()
        {
            AppliedMaterials = new List<InstalledMaterial>();
        }

        /// <summary>
        /// The id of the work transaction with which this message is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific materials which were applied.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<InstalledMaterial> AppliedMaterials
        {
            get;
            set;
        }
    }
}
