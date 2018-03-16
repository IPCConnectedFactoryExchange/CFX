using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class EndpointConnected : CFXMessage
    {
        public string CFXHandle
        {
            get;
            set;
        }

        public string RequestNetworkUri
        {
            get;
            set;
        }

        /// <summary>
        /// Optional field if a single network host is servicing multiple endpoints.  For AMQP, corresponds to the AMQP 1.0 target address.
        /// </summary>
        public string RequestTargetAddress
        {
            get;
            set;
        }
    }
}
