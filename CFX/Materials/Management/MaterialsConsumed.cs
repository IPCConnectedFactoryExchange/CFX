using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent by a process endpoint when materials are consumed
    /// <code language="none">
    /// {
    ///   "ConsumedMaterials": [
    ///     {
    ///       "MaterialLocation": {
    ///         "LocationIdentifier": "3245434554",
    ///         "LocationName": "SLOT22",
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": "MAT238908348903",
    ///           "InternalPartNumber": "IPN-1222-55555",
    ///           "Quantity": 344.0
    ///         },
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": null,
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 4.0,
    ///           "UniqueIdentifier": "234232432424",
    ///           "Name": "FEEDER2245465"
    ///         }
    ///       },
    ///       "QuantityUsed": 42.0,
    ///       "QuantitySpoiled": 2.0,
    ///       "RemainingQuantity": 344.0
    ///     },
    ///     {
    ///       "MaterialLocation": {
    ///         "LocationIdentifier": "3245435784",
    ///         "LocationName": "SLOT28",
    ///         "MaterialPackage": {
    ///           "UniqueIdentifier": "MAT238908323434",
    ///           "InternalPartNumber": "IPN-1222-11111",
    ///           "Quantity": 258.0
    ///         },
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": null,
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 8.0,
    ///           "TapePitch": 4.0,
    ///           "UniqueIdentifier": "234232432424",
    ///           "Name": "FEEDER2245465"
    ///         }
    ///       },
    ///       "QuantityUsed": 88.0,
    ///       "QuantitySpoiled": 3.0,
    ///       "RemainingQuantity": 258.0
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsConsumed : CFXMessage
    {
        public MaterialsConsumed()
        {
            ConsumedMaterials = new List<ConsumedMaterial>();
        }

        /// <summary>
        /// A list of one or more materials that have been consumed
        /// </summary>
        public List<ConsumedMaterial> ConsumedMaterials
        {
            get;
            set;
        }
    }
}
