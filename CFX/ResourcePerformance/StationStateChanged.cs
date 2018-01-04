using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    public class StationStateChanged : CFXMessage
    {
        public ResourceState OldState
        {
            get;
            set;
        }

        public TimeSpan OldStateDuration
        {
            get;
            set;
        }

        public ResourceState NewState
        {
            get;
            set;
        }

        public Fault RelatedFault
        {
            get;
            set;
        }
    }
}
