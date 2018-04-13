using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent when two separate material packages (containing the same part) are joined together.
    /// For example, as in the case of the splicing together of multiple reels of embossed tape
    /// containing SMD parts.
    /// <code language="none">
    /// {
    ///   "LeadingMaterialPackage": {
    ///     "UniqueIdentifier": "MAT4566589856",
    ///     "InternalPartNumber": "IPN45577",
    ///     "Quantity": 151.0
    ///   },
    ///   "TrailingMaterialPackage": {
    ///     "UniqueIdentifier": "MAT4563453457",
    ///     "InternalPartNumber": "IPN45577",
    ///     "Quantity": 151.0
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class MaterialsJoined : CFXMessage
    {
        /// <summary>
        /// Of the two material packages being joined, the material package which will be consumed
        /// first after joining
        /// </summary>
        public MaterialPackage LeadingMaterialPackage
        {
            get;
            set;
        }

        /// <summary>
        /// Of the two material packages being joined, the material package which will be consumed
        /// last after joining
        /// </summary>
        public MaterialPackage TrailingMaterialPackage
        {
            get;
            set;
        }
    }
}
