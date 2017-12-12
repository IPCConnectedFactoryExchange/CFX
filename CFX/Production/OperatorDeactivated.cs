using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class OperatorDeactivated : CFXMessage
    {
        public Operator Operator
        {
            get;
            set;
        }
    }
}
