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
    public class WorkCompleted : CFXMessage 
    {
        public Guid TransactionID
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
