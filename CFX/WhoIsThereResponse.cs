using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX
{
    public class WhoIsThereResponse : CFXMessage
    {
        public WhoIsThereResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            set;
        }

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
