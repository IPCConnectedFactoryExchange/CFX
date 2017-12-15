using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    public class GetTransportOrderStatusRequest : CFXMessage
    {
        public string TransportOrderNumber
        {
            get;
            set;
        }
    }
}
