using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class BlockMaterialLocationResponse : CFXMessage
    {
        public BlockMaterialLocationResponse()
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
