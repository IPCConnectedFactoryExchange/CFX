using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Storage
{
    public class ValidateStationSetupResponse : CFXMessage
    {
        public ValidateStationSetupResponse()
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
