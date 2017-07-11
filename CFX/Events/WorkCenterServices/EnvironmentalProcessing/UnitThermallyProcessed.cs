using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Events.WorkCenterServices.EnvironmentalProcessing
{
    public class UnitThermallyProcessed
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

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }
        




    }
}
