using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Management
{
    /// <summary>
    /// A request (typically to an factory level software system) to obtain detailed information about a particular material package (or collection of 
    /// material packages).
    /// <code language="none">
    /// {
    ///   "MaterialPackageIdentifiers": [
    ///     "MAT4566556456",
    ///     "MAT4566554543"
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class GetMaterialInformationRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GetMaterialInformationRequest()
        {
            MaterialPackageIdentifiers = new List<string>();
        }

        /// <summary>
        /// A list of the unique identifiers of the material packages for which detailed
        /// information is requested.
        /// </summary>
        public List<string> MaterialPackageIdentifiers
        {
            get;
            set;
        }
    }
}
