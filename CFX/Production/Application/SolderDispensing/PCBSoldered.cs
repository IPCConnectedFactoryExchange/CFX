using System;
using System.Collections.Generic;
using System.Text;
using CFX;
using CFX.Structures;
using CFX.Structures.SolderDispensing;

namespace CFX.Production.Application.SolderDispensing
{
    public class PCBSoldered : CFXMessage
    {
        public string TransactionId { get; set; }

        public List<SolderedPCB> SolderedPCBs { get; set; }
    }
}
