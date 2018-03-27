using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint whenever a fault is encountered. A data structure must be included in the message related to specific equipment type.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class FaultOccurred : CFXMessage
    {
        public FaultOccurred()
        {
            Fault = new Fault();
        }

        /// <summary>
        /// Dynamic structure provi
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Fault Fault
        {
            get;
            set;
        }
    }
}
