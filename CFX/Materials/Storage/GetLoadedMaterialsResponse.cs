using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// A response to a request to a material storage endpoint to obtain a list of all the materials
    /// currently stored within the endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "SETUP OK"
    ///   },
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
    ///       "LocationName": "SLOT50",
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
    ///         "Width": "Tape8mm",
    ///         "Pitch": "Adjustable",
    ///         "UniqueIdentifier": "1233334",
    ///         "Name": "TAPEFEEDER8mm1233334"
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
    public class GetLoadedMaterialsResponse : CFXMessage
    {
        public GetLoadedMaterialsResponse()
        {
            Materials = new List<MaterialLocation>();
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
        /// A list of the materials stored at the process endpoint, including
        /// storage location information.
        /// </summary>
        public List<MaterialLocation> Materials
        {
            get;
            set;
        }
    }
}
