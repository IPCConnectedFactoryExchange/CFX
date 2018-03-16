using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class GetEndpointInformationRequest : CFXMessage
    {
        public string CFXHandle
        {
            get;
            set;
        }
    }
}
