using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Management
{
    public class BlockMaterialsResponse : CFXMessage
    {
        public BlockMaterialsResponse()
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
