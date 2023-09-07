using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Storage
{
    /// <summary>
    /// A request to a material storage endpoint to obtain a list of all the materials
    /// currently stored within the endpoint.
    /// <code language="none">
    /// {
    ///   "LocationIdentifiers": null
    /// }
    /// </code>
    /// </summary>
    public class GetLoadedMaterialsRequest : CFXMessage
    {
        /// <summary>
        /// An optional list of specific locations in which the requestor is interested.
        /// If empty, all materials loaded at the Endpoint are returned.
        /// </summary>
        public List<string> LocationIdentifiers
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.7 **</para>
        /// The unique identifier of the resource in which the requestor is interested (optional)
        /// If set to null, the search is made on the endpoint itself.
        /// The use of this property should be reserved to an endpoint that is able to know the location of all the MaterialPackage of the factory, like an ERP for example
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.7")]
        public string ResourceUniqueIdentifier
        {
            get;
            set;
        }
    }
}
