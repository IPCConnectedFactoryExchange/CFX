using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent to a process endpoint to release a material locations block which was put
    /// into place by a previously sent BlockMaterialLocationsRequest
    /// <code language="none">
    /// {
    ///   "Locations": [
    ///     {
    ///       "LocationIdentifier": "23143433",
    ///       "LocationName": "SLOT45",
    ///       "MaterialPackage": null,
    ///       "CarrierInformation": null
    ///     },
    ///     {
    ///       "LocationIdentifier": "23143454",
    ///       "LocationName": "SLOT46",
    ///       "MaterialPackage": null,
    ///       "CarrierInformation": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class UnblockMaterialLocationsRequest : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnblockMaterialLocationsRequest()
        {
            Locations = new List<MaterialLocation>();
        }

        /// <summary>
        /// A list of locations to be unblocked
        /// </summary>
        public List<MaterialLocation> Locations
        {
            get;
            set;
        }
    }
}
