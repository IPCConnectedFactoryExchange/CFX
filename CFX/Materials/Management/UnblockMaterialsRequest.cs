using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// A request to unblock one or more particular lots or instances of material from use in production.
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
    public class UnblockMaterialsRequest : CFXMessage
    {
        public UnblockMaterialsRequest()
        {
            MaterialPackageIdentifiers = new List<string>();
        }

        /// <summary>
        /// A list of the unique identifiers of the material packages to be blocked
        /// </summary>
        public List<string> MaterialPackageIdentifiers
        {
            get;
            set;
        }

        /// <summary>
        /// Human readable comments describing the nature of the block (optional)
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// The person responsible for removing the block
        /// </summary>
        public Operator Unblocker
        {
            get;
            set;
        }
    }
}
