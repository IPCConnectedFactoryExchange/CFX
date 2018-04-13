using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// A request to block one or more particular lots or instances of material from use in production.
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
    public class BlockMaterialsRequest : CFXMessage
    {
        public BlockMaterialsRequest()
        {
            MaterialPackageIdentifiers = new List<string>();
            Blocker = new Operator();
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
        /// An enumeration describing the reason for the block
        /// </summary>
        public BlockReason Reason
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
        /// The person responsible for initiating this block
        /// </summary>
        public Operator Blocker
        {
            get;
            set;
        }
    }
}
