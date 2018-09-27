using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Enumeration used for matching an endpoint's capabilities to a list of CFX topics.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SupportedTopicQueryType
    {
        /// <summary>
        /// The endpoint must support ALL topics specified in the supported topics list.
        /// </summary>
        All,
        /// <summary>
        /// The endpoint must support one or more of the topics specified in the supported topics list.
        /// </summary>
        Any,
        /// <summary>
        /// The supported topics list will be ignored.
        /// </summary>
        Ignore
    }
}
