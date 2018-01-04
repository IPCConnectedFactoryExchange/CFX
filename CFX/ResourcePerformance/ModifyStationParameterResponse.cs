using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    public class ModifyStationParameterResponse : CFXMessage
    {
        public ModifyStationParameterResponse()
        {
            Result = new RequestResult();
        }

        public RequestResult Result
        {
            get;
            set;
        }

        public string ParameterName
        {
            get;
            set;
        }

        public string OldParameterValue
        {
            get;
            set;
        }

        public string NewParameterValue
        {
            get;
            set;
        }
    }
}
