using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    public class UnblockMaterialLocationResponse : CFXMessage
    {
        public UnblockMaterialLocationResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            set;
        }
    }
}
