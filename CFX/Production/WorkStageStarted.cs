using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Production
{
    /// <summary>
    /// Indicates that work has begun on one or more production units at a particular work center.
    /// </summary>
    public class WorkStageStarted : CFXMessage
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
    }
}
