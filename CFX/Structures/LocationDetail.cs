using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// Describes detailed information about a particular location. This is a dynamic structure
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class LocationDetail
    {
        /// <summary>
        /// The unique identifier (barcode) of the location on the Endpoint / Resource where the MaterialPackage is to be loaded.
        /// If this property is left empty, the MaterialPackage will only be loaded to the carrier specified
        /// by the CarrierInformation property, and not to an Endpoint / Resource.
        /// </summary>
        public string LocationIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the carrier location
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }
    }
}
