using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.ReflowProfiling
{
    /// <summary>
    /// A dynamic structure which describes a fault that has occurred in the course of production.
    /// </summary>
    public class FaultClear : Fault
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FaultClear()
        {
        }

        /// <summary>
        /// Time and date fault was cleared in ISO 8061 Datetime format. 
        /// </summary>
        public string TimeDateFaultEvent
        {
            get;
            set;
        }
    }
}
