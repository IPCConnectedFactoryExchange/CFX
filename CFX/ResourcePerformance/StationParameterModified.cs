using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    public class StationParameterModified : CFXMessage
    {
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
