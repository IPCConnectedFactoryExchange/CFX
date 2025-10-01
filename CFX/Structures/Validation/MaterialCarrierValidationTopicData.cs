using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Validation
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Data structure representing the Material Carriers that need to be validated.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class MaterialCarrierValidationTopicData : ValidationData
    {
        /// <summary>
        /// List of Material Carriers on Locations to be validated.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<MaterialCarrierLocation> ValidationTopicData
        {
            get;
            set;
        }
    }
}
