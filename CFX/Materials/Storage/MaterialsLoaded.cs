using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when a material package (potentially contained within a material carrier)
    /// is loaded at a process endpoint.
    /// <code language="none">
    /// {
    ///   "Materials": [
    ///     {
    ///       "LocationIdentifier": "5555646453",
    ///       "LocationName": "SLOT45",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566556456",
    ///         "InternalPartNumber": "IPN47788",
    ///         "Quantity": 887.0
    ///       },
    ///       "CarrierInformation": {
    ///         "UniqueIdentifier": "1233333",
    ///         "Name": null
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646454",
    ///       "LocationName": "SLOT44",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566554543",
    ///         "InternalPartNumber": "IPN48899",
    ///         "Quantity": 748.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": "123334",
    ///         "BaseName": null,
    ///         "LaneNumber": 1,
    ///         "TapeWidth": 8.0,
    ///         "TapePitch": 8.0,
    ///         "UniqueIdentifier": "1233334",
    ///         "Name": "TAPEFEEDER8mm1233334"
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646455",
    ///       "LocationName": "SLOT45",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566553421",
    ///         "InternalPartNumber": "IPN45577",
    ///         "Quantity": 151.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": "123335",
    ///         "BaseName": "MULTILANEFEEDER123335",
    ///         "LaneNumber": 1,
    ///         "TapeWidth": 8.0,
    ///         "TapePitch": 4.0,
    ///         "UniqueIdentifier": "1233335A",
    ///         "Name": "TAPEFEEDER8mm1233335A"
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646455",
    ///       "LocationName": "SLOT45",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566555547",
    ///         "InternalPartNumber": "IPN45577",
    ///         "Quantity": 151.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": "123335",
    ///         "BaseName": "MULTILANEFEEDER123335",
    ///         "LaneNumber": 2,
    ///         "TapeWidth": 8.0,
    ///         "TapePitch": 4.0,
    ///         "UniqueIdentifier": "1233335B",
    ///         "Name": "TAPEFEEDER8mm1233335B"
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646456",
    ///       "LocationName": "SLOT46",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566588751",
    ///         "InternalPartNumber": "IPN45577",
    ///         "Quantity": 151.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTubeFeeder, CFX",
    ///         "BaseUniqueIdentifier": "123336",
    ///         "BaseName": null,
    ///         "LaneNumber": 0,
    ///         "Width": 12.0,
    ///         "Pitch": 24.0,
    ///         "UniqueIdentifier": "1233336",
    ///         "Name": "TUBE1233336"
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646457",
    ///       "LocationName": "92.1",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "MAT4566589856",
    ///         "InternalPartNumber": "IPN45577",
    ///         "Quantity": 151.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTrayFeeder, CFX",
    ///         "CellDimensionX": 17.0,
    ///         "CellDimensionY": 17.0,
    ///         "CellCountX": 8,
    ///         "CellCountY": 3,
    ///         "CellPitchX": 0.0,
    ///         "CellPitchY": 0.0,
    ///         "UniqueIdentifier": "1233337",
    ///         "Name": "MATRIXTRAY1233337"
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsLoaded : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialsLoaded()
        {
            Materials = new List<MaterialLocation>();
        }

        /// <summary>
        /// There are three usage cases are available for this message:
        ///     1) Load MaterialPackage directly to Endpoint 
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = null)
        ///     2) Load MaterialPackage to MaterialCarrier
        ///        (LocationIdentifier = null, CarrierInformation = Identifier of carrier to be loaded)
        ///     3) Load MaterialPackage to MaterialCarrier AND Load MaterialCarrier to Endpoint
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = Identifier of carrier to be loaded)
        /// </summary>
        public List<MaterialLocation> Materials
        {
            get;
            set;
        }
    }
}
