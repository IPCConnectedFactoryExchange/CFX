using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialLocation
    {
        /// <summary>
        /// The unique identifier of the location on the Endpoint where the MaterialPackage is to be loaded.
        /// If this property is left empty, the MaterialPackage will only be loaded to the carrier specified
        /// by the CarrierInformation property, and not to an Endpoint.
        /// </summary>
        public string LocationIdentifier
        {
            get;
            set;
        }

        public string LocationName
        {
            get;
            set;
        }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.None)]
        public MaterialPackage MaterialPackage
        {
            get;
            set;
        }

        [JsonProperty(ItemTypeNameHandling  = TypeNameHandling.Auto)]
        public MaterialCarrier CarrierInformation
        {
            get;
            set;
        }
    }
}
