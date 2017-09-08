using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.DataObjects;

namespace CFX.Production
{
    public class LockStationResponse : CFXMessage
    {
        public StatusResult Result
        {
            get;
            set;
        }
    }
}
