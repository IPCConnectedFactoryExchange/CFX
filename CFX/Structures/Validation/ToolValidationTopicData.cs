using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Validation
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Data structure representing the Tool(s) that need to be validated.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolValidationTopicData : ValidationData
    {
        /// <summary>
        /// List of Tools to be validated.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Tool> ValidationTopicData
        {
            get;
            set;
        }
    }
}
