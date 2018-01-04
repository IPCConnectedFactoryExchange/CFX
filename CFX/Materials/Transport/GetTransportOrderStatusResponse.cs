using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Transport
{
    public class GetTransportOrderStatusResponse : CFXMessage
    {
        public GetTransportOrderStatusResponse()
        {
            Result = new RequestResult();
            History = new List<TransportOrderHistory>();
        }

        public RequestResult Result
        {
            get;
            set;
        }

        public string TransportOrderNumber
        {
            get;
            set;
        }

        public string FinalDestination
        {
            get;
            set;
        }

        public TransportOrderStatus Status
        {
            get;
            set;
        }

        public List<TransportOrderHistory> History
        {
            get;
            set;
        }
    }
}
