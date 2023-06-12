using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a specific location on an endpoint where material may be loaded.
    /// Also includes information about the current contents of this location (if applicable).
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialLocation
    {
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.7 **</para>
        /// The ResourceLocation on which the material is located (optional)
        /// If null, it is assumed that the Resource is the one associated to the source Endpoint
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.7")]
        public ResourceLocation ResourceLocation
        {
            get;
            set;
        }

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
        /// Name of the Location
        /// </summary>
        public string LocationName
        {
            get;
            set;
        }

        /// <summary>
        /// The material package (reel, bin, etc) that is loaded at the position (if any).
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.None)]
        public MaterialPackage MaterialPackage
        {
            get;
            set;
        }

        /// <summary>
        /// The material carrier that is loaded at the position (if any)
        /// </summary>
        [JsonProperty(ItemTypeNameHandling  = TypeNameHandling.Auto)]
        public MaterialCarrier CarrierInformation
        {
            get;
            set;
        }
    }
}
