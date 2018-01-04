using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    public class StationOnline : CFXMessage
    {
        public TimeSpan OfflineDuration
        {
            get;
            set;
        }
    }
}
