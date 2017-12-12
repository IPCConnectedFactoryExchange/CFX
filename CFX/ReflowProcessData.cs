using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX
{
    public class ReflowProcessData
    {
        public ReflowProcessData()
        {
            ZoneProcessData = new List<CFX.ZoneReflowProcessData>();
        }

        public List<ZoneReflowProcessData> ZoneProcessData
        {
            get;
            set;
        }
    }
}
