using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    public class StageStateChanged : CFXMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceState OldState
        {
            get;
            set;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceState NewState
        {
            get;
            set;
        }
    }
}
