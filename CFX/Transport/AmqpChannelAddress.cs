using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Transport
{
    public class AmqpChannelAddress
    {
        public Uri Uri
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
    }
}
