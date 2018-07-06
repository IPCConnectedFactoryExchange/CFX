using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderDispensing
{
    public class SolderedPCB
    {
        public string UnitIdentifier { get; set; }
        public int UnitPositionNumber { get; set; }
        public SolderingData HeaderData { get; set; }
        public List<ZoneData> ZoneData { get; set; }
    }
}
