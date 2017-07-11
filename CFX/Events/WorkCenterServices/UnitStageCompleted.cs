using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.WorkCenterServices
{
    public class UnitStageCompleted
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

        public string StageName
        {
            get;
            set;
        }
    }
}
