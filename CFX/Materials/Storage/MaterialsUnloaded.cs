using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// Sent when a material package (potentially contained within a material carrier)
    /// is unloaded at an endpoint.
    /// <code language="none">
    /// {
    ///   "MaterialPackageIdentifiers": [
    ///     "MAT4566556456",
    ///     "MAT4566554543",
    ///     "MAT4566553421",
    ///     "MAT4566555547"
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class MaterialsUnloaded : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaterialsUnloaded()
        {
            MaterialPackageIdentifiers = new List<string>();
        }

        /// <summary>
        /// List of material package identifiers to be unloaded.  
        /// </summary>
        public List<string> MaterialPackageIdentifiers
        {
            get;
            set;
        }
    }
}
