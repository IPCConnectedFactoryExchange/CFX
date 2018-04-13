using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// Sent when one or more material packages are fully exhausted / depleted
    /// <code language="none">
    /// {
    ///   "Materials": [
    ///     {
    ///       "UniqueIdentifier": "MAT4566556456",
    ///       "InternalPartNumber": "IPN47788",
    ///       "Quantity": 887.0
    ///     },
    ///     {
    ///       "UniqueIdentifier": "MAT4566554543",
    ///       "InternalPartNumber": "IPN48899",
    ///       "Quantity": 748.0
    ///     },
    ///     {
    ///       "UniqueIdentifier": "MAT4566553421",
    ///       "InternalPartNumber": "IPN45577",
    ///       "Quantity": 151.0
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsRetired : CFXMessage
    {
        public MaterialsRetired()
        {
            Materials = new List<MaterialPackage>();
        }

        /// <summary>
        /// A list of the materials that have been exhausted / depleted
        /// </summary>
        public List<MaterialPackage> Materials
        {
            get;
            set;
        }
    }
}
