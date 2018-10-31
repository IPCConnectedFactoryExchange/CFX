using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to query the equipment for a list of active faults.
    /// <see cref="GetActiveFaultsResponse"/> message that it sends back to the requester.
    /// <code language="none">
    /// {}
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetActiveFaultsRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public GetActiveFaultsRequest()
        {
        }

    }
}
