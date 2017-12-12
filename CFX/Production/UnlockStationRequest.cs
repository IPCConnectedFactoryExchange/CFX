using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production
{
    public class UnlockStationRequest : CFXMessage
    {
        public Operator Requestor
        {
            get;
            set;
        }
    }
}
