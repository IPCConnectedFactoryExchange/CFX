using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    public enum WorkResult
    {
        COMPLETED,
        FAILED,
        ABORTED
    }

    public class WorkCompleted
    {
        public Guid TransactionID
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
