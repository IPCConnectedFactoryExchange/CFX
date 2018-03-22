using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// Sent when an Endpoint joins a CFX network after it has been established. 
    /// Provides the same information as the response to the AreYouThereRequest 
    /// message. Need not be used for short-term machine to machine connection, 
    /// where for example only a simple request / response message is being exchanged.
    /// </summary>
    public class EndpointConnected : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint that is responding
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }

        /// <summary>
        /// The network address / Uri to be used for requests to this endpoint
        /// </summary>
        public string RequestNetworkUri
        {
            get;
            set;
        }

        /// <summary>
        /// The AMQP 1.0 target address to be used for requests to this endpoint
        /// </summary>
        public string RequestTargetAddress
        {
            get;
            set;
        }
    }
}
