using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    public class ToolsUsed : CFXMessage
    {
        public ToolsUsed()
        {
            UsedTools = new List<ToolUsed>();
        }

        public Guid TransactionId
        {
            get;
            set;
        }

        public List<ToolUsed> UsedTools
        {
            get;
            set;
        }
    }
}
