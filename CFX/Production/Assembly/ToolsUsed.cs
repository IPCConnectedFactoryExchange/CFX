using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Assembly
{
    /// <summary>
    /// Sent by a process endpoint when one or more tools are used in the course of performing an assembly operation.
    /// </summary>
    public class ToolsUsed : CFXMessage
    {
        public ToolsUsed()
        {
            UsedTools = new List<ToolUsed>();
        }

        /// <summary>
        /// The id of the work transaction with which this installation is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the tools that were used
        /// </summary>
        public List<ToolUsed> UsedTools
        {
            get;
            set;
        }
    }
}
