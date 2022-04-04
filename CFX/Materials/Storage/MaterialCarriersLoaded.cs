using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when a material carrier (typcially containing 1 or more material packages)
    /// is loaded at an endpoint.
    /// <code language="none">
    /// {
    ///   "Carriers": [
    ///     {
    ///       "LocationIdentifier": "5555646453",
    ///       "LocationName": null,
    ///       "CarrierInformation": {
    ///         "UniqueIdentifier": "1233333",
    ///         "Name": null
    ///       }
    ///     },
    ///     {
    ///       "LocationIdentifier": "5555646455",
    ///       "LocationName": "LANEA",
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
    ///       "LocationName": "LANEB",
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
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialCarriersLoaded : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialCarriersLoaded()
        {
            Carriers = new List<MaterialCarrierLocation>();
        }

        /// <summary>
        /// There are two usage cases are available for this message:
        ///     1) Load MaterialCarrier directly to Endpoint 
        ///        (LocationIdentifier = Endpoint Slot Identifier, CarrierInformation = Carrier to be loaded)
        ///     2) Load MateriialCarrier to another MaterialCarrier
        ///        (LocationIdentifier = Identifier of new parent carrier, CarrierInformation = Identifier of carrier to be loaded)
        /// </summary>
        public List<MaterialCarrierLocation> Carriers
        {
            get;
            set;
        }
    }
}
