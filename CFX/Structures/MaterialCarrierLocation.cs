using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a specific location on an endpoint where a material carrier may be loaded.
    /// When applicable, also contains information about the currently loaded carrier, and
    /// the material package(s) loaded to that carrer.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialCarrierLocation
    {
        /// <summary>
        /// The unique identifier of the carrier location (barcode or RFID value)
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

        /// <summary>
        /// Dynamic structure that defines the carrier that is presently loaded at the carrier location
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public MaterialCarrier CarrierInformation
        {
            get;
            set;
        }
    }
}
