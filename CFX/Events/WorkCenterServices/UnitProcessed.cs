using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.WorkCenterServices
{
    public class UnitProcessed
    {
        public Guid UnitTransactionID
        {
            get;
            set;
        }

        public string UnitIdentifier
        {
            get;
            set;
        }

        public DateTime ProcessStartTime
        {
            get;
            set;
        }

        public DateTime ProcessCompletedTime
        {
            get;
            set;
        }

        public object ProcessData
        {
            get;
            set;
        }
    }
}
