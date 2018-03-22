using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    /// <summary>
    /// Requests detailed information about a single specified of a specified endpoint. 
    /// The response includes information regarding the endpoint’s capabilities
    /// (CFX topic and message support), as well as a generic model of its
    /// physical layout (zones, lanes, etc).
    /// </summary>
    public class GetEndpointInformationRequest : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint about which the sender wishes to obtain information.
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }
    }
}
