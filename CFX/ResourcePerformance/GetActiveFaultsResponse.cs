using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Response to an external source to modify a generic configuration parameter of a process endpoint.
    /// </summary>
    public class GetActiveFaultsResponse : CFXMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveFaultsResponse"/> class.
        /// </summary>
        public GetActiveFaultsResponse()
        {
            Result = new RequestResult();
            ActiveFaults = new List<Fault>();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }


        public List<Fault> ActiveFaults
        {
            get;
            set;
        }
    }
}
