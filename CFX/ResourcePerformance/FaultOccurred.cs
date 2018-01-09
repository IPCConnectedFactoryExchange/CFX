using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class FaultOccurred : CFXMessage
    {
        public FaultOccurred()
        {
            Fault = new Fault();
        }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Fault Fault
        {
            get;
            set;
        }
    }
}
