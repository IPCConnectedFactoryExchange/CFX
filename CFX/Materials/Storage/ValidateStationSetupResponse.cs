using System;
using System.Collections.Generic;
using System.Text;

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
