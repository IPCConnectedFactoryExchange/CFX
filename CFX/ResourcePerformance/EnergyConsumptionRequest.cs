using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to inquire data regarding energy consumption of the endpoint
    /// <see cref="EnergyConsumptionResponse"/> message that it sends back to the requester.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class EnergyConsumptionRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public EnergyConsumptionRequest()
        {
        }
    }
}
