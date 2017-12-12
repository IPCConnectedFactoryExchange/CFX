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
    public class LockLaneRequest : CFXMessage
    {
        public LockReason Reason
        {
            get;
            set;
        }

        public string Lane
        {
            get;
            set;
        }

        public Operator Requestor
        {
            get;
            set;
        }
    }
}
