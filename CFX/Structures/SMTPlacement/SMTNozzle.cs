using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.SMTPlacement
{
    public class SMTNozzle : Tool
    {
        /// <summary>
        /// The name or identifier of the SMT head associated with this SMT Nozzle.
        /// </summary>
        public string HeadId
        {
            get;
            set;
        }

        /// <summary>
        /// The spindle number on the head to which this SMT Nozzle is attached
        /// </summary>
        public int HeadNozzleNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The type or model name of this SMT Nozzle
        /// </summary>
        public string NozzleType
        {
            get;
            set;
        }
    }
}
