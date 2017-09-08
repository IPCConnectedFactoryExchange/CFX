using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.DataObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    public class LockStationRequest : CFXMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LockReason ReasonCode
        {
            get;
            set;
        }
    }
}
