using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This message allows an external source to modify a generic configuration parameter of a process endpoint.
    /// </summary>
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
