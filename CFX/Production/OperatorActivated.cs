using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

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
