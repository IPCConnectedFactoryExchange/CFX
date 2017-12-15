using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialCarrierLocation
    {
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

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public MaterialCarrier CarrierInformation
        {
            get;
            set;
        }
    }
}
