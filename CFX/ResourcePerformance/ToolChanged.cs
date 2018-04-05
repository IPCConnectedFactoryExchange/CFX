using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SMTPlacement;

namespace CFX.ResourcePerformance.SMTPlacement
{
    /// <summary>
    /// Sent when a new tool is selected for active use at a production endpoint
    /// </summary>
    public class ToolChanged : CFXMessage
    {
        public ToolChanged()
        {
        }

        /// <summary>
        /// The tool that was previously in active use (if any) 
        /// </summary>
        public Tool OldTool
        {
            get;
            set;
        }

        /// <summary>
        /// The location on the endpoint where the old tool was returned (if any)
        /// </summary>
        public ToolHolder ReturnedToHolder
        {
            get;
            set;
        }

        /// <summary>
        /// The new active tool
        /// </summary>
        public Tool NewTool
        {
            get;
            set;
        }

        /// <summary>
        /// The location on the endpoint from which the newly active tool was selected 
        /// </summary>
        public ToolHolder LoadedFromHolder
        {
            get;
            set;
        }
    }
}
