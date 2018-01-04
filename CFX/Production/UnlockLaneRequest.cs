using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.Production
{
    public class UnlockLaneRequest : CFXMessage
    {
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
