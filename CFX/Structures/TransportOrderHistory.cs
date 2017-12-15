using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class TransportOrderHistory
    {
        public DateTime? EventDateTime
        {
            get;
            set;
        }

        public TransportOrderStatus Status
        {
            get;
            set;
        }

        public Operator Operator
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }
    }
}
