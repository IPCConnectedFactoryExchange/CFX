using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    public class StageStateChanged : CFXMessage
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
    }
}
