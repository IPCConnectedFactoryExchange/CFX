using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Response to UnblockMaterialLocationsRequest
    /// </summary>
    public class UnblockMaterialLocationsResponse : CFXMessage
    {
        public UnblockMaterialLocationsResponse()
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
