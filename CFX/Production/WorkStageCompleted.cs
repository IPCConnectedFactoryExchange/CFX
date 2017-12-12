using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;

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

        public WorkResult Result
        {
            get;
            set;
        }
    }
}
