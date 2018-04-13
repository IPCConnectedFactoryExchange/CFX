using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when one or more material packages stored at a particular location
    /// become fully exhausted / depleted.
    /// <code language="none">
    /// {
    ///   "EmptyMaterials": [
    ///     {
    ///       "LocationIdentifier": "3245434554",
    ///       "LocationName": "SLOT22",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT238908348903",
    ///         "InternalPartNumber": "IPN-1222-55555",
    ///         "Quantity": 0.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": null,
    ///         "BaseName": null,
    ///         "LaneNumber": 1,
    ///         "Width": "Tape8mm",
    ///         "Pitch": "Pitch8mm",
    ///         "UniqueIdentifier": "234232432424",
    ///         "Name": "FEEDER2245465"
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "3245435784",
    ///       "LocationName": "SLOT28",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT238908323434",
    ///         "InternalPartNumber": "IPN-1222-11111",
    ///         "Quantity": 0.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": null,
    ///         "BaseName": null,
    ///         "LaneNumber": 1,
    ///         "Width": "Tape8mm",
    ///         "Pitch": "Pitch8mm",
    ///         "UniqueIdentifier": "234232432424",
    ///         "Name": "FEEDER2245465"
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsEmpty : CFXMessage
    {
        public MaterialsEmpty()
        {
            EmptyMaterials = new List<MaterialLocation>();
        }

        /// <summary>
        /// A list of the material locations where the depleted material packages are stored or loaded
        /// at the endpoint.  Also includes the material package that is loaded at the location (if known).
        /// For example, if the endpoint is an SMT placement machine, the location identifies 
        /// the feeder slot/position where the depleted material package is loaded.
        /// </summary>
        public List<MaterialLocation> EmptyMaterials
        {
            get;
            set;
        }
    }
}
