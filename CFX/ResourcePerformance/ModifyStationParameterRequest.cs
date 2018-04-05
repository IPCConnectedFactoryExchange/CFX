using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to modify a generic configuration parameter of a process endpoint.
    /// Upon successful processing of this request, the endpoint should publish a <see cref="StationParameterModified"/> message in addition to the 
    /// <see cref="ModifyStationParameterResponse"/> message that it sends back to the requester.
    /// </summary>
    public class ModifyStationParameterRequest : CFXMessage
    {
        /// <summary>
        /// The name of the configuration parameter
        /// </summary>
        public string ParameterName
        {
            get;
            set;
        }

        /// <summary>
        /// The new value for the configuration parameter
        /// </summary>
        public string ParameterValue
        {
            get;
            set;
        }
    }
}
