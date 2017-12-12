using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production
{
    public class OperatorActivated : CFXMessage
    {
        public Operator Operator
        {
            get;
            set;
        }
    }
}
