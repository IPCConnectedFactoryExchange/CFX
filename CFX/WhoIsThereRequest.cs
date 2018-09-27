using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to discover all of the other endpoints participating in this CFX network, 
    /// and their capabilities. All other CFX endpoints matching the specified criteria
    /// must then respond to this broadcast.  The response includes the endpoint's identity (CFX Handle),
    /// as well as the information needed to contact the endpoint.
    /// <code language="none">
    /// {
    ///   "SupportedTopicQueryType": "All",
    ///   "SupportedTopics": [
    ///     {
    ///       "TopicName": "CFX.Production",
    ///       "TopicSupportType": "Publisher",
    ///       "SupportedMessages": []
    ///     },
    ///     {
    ///       "TopicName": "CFX.Production.Appplication",
    ///       "TopicSupportType": "Publisher",
    ///       "SupportedMessages": []
    ///     }
    ///   ]
    /// }
    /// </code>
    ///</summary>
    public class WhoIsThereRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WhoIsThereRequest()
        {
            SupportedTopics = new List<SupportedTopic>();
            SupportedTopicQueryType = SupportedTopicQueryType.Ignore;
        }

        /// <summary>
        /// If the sender is interested only in certain types of endpoints, 
        /// tbis property specifies how SupportedTopics list will be interpreted.
        /// </summary>
        public SupportedTopicQueryType SupportedTopicQueryType
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of CFX topics.  Only machines supporting any or all of these
        /// CFX topics will respond to this broadcast.
        /// </summary>
        public List<SupportedTopic> SupportedTopics
        {
            get;
            set;
        }
    }
}
