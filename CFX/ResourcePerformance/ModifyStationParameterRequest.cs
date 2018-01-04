using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    public class ModifyStationParameterRequest : CFXMessage
    {
        public string ParameterName
        {
            get;
            set;
        }

        public string ParameterValue
        {
            get;
            set;
        }
    }
}
