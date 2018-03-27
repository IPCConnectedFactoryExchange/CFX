using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Indicates the type of support an endpoint has for a particular topic.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TopicSupportType
    {
        /// <summary>
        /// The endpoint publishes outbound messages for this topic, and responds to inbound requests
        /// </summary>
        Publisher,
        /// <summary>
        /// The endpoint consumes the messages of this topic that are produced by other endpoints
        /// </summary>
        Consumer,
        /// <summary>
        /// The endpoint publishes outbound messages for this topic, responds to inbound request, and
        /// consumes the messages of this topic that are produced by other endpoints
        /// </summary>
        PublisherConsumer
    }
}
