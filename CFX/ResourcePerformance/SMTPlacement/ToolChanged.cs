using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SMTPlacement;

namespace CFX.ResourcePerformance.SMTPlacement
{
    public class ToolChanged : CFXMessage
    {
        public ToolChanged()
        {
        }

        public SMTNozzle OldNozzle
        {
            get;
            set;
        }

        public SMTNozzleHolder ReturnedToHolder
        {
            get;
            set;
        }

        public SMTNozzle NewNozzle
        {
            get;
            set;
        }

        public SMTNozzleHolder LoadedFromHolder
        {
            get;
            set;
        }
    }
}
