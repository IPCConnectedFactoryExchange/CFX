using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when an endpoint detects a splice point.  A splice point is a juncture between two different material packages 
    /// of the same part that have been pre-joined prior to loading at the material location, or were joined-in-place
    /// during production.  Though the two materials are of the same part number, they may be of differing lots.
    /// <code language="none">
    /// {
    ///   "DepletedMaterial": {
    ///     "LocationIdentifier": "3245434554",
    ///     "LocationName": "SLOT22",
    ///     "MaterialPackage": {
    ///       "UniqueIdentifier": "MAT238908348903",
    ///       "InternalPartNumber": "IPN-1222-55555",
    ///       "Quantity": 0.0
    ///     },
    ///     "CarrierInformation": {
    ///       "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///       "BaseUniqueIdentifier": null,
    ///       "BaseName": null,
    ///       "LaneNumber": 1,
    ///       "TapeWidth": 8.0,
    ///       "TapePitch": 8.0,
    ///       "UniqueIdentifier": "234232432424",
    ///       "Name": "FEEDER2245465"
    ///     }
    ///   },
    ///   "NewlyActiveMaterial": {
    ///     "LocationIdentifier": "3245435784",
    ///     "LocationName": "SLOT28",
    ///     "MaterialPackage": {
    ///       "UniqueIdentifier": "MAT238908348904",
    ///       "InternalPartNumber": "IPN-1222-55555",
    ///       "Quantity": 1000.0
    ///     },
    ///     "CarrierInformation": {
    ///       "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///       "BaseUniqueIdentifier": null,
    ///       "BaseName": null,
    ///       "LaneNumber": 1,
    ///       "TapeWidth": 8.0,
    ///       "TapePitch": 8.0,
    ///       "UniqueIdentifier": "234232432424",
    ///       "Name": "FEEDER2245465"
    ///     }
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class SplicePointDetected : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SplicePointDetected()
        {
        }

        /// <summary>
        /// Describes the location on the machine where a splice point was detected, along with 
        /// information about the material package that has been depleted.
        /// </summary>
        public MaterialLocation DepletedMaterial
        {
            get;
            set;
        }

        /// <summary>
        /// Describes the location on the machine where a splice point was detected, along with 
        /// information about the new material package that is now being actively consumed at 
        /// that location.
        /// </summary>
        public MaterialLocation NewlyActiveMaterial
        {
            get;
            set;
        }
    }
}
