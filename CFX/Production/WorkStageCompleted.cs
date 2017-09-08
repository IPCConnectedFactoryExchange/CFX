using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.DataObjects;

namespace CFX.Production
{
    public class WorkStageCompleted : CFXMessage
    {
        public Guid TransactionID
        {
            get;
            set;
        }

        public string Stage
        {
            get;
            set;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public WorkResult Result
        {
            get;
            set;
        }
    }
}
