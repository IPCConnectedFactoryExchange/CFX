using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// Sent when an endpoint is about to shut down and disconnect from a CFX network
    /// </summary>
    public class EndpointShuttingDown : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint that is shutting down
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }
    }
}
