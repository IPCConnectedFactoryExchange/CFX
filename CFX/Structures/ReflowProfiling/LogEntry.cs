using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.ReflowProfiling
{
    /// <summary>
    /// A dynamic structure which describes a log event that has occurred in the course of production.
    /// </summary>
    public class LogEntry : Fault
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public LogEntry()
        {
        }

        /// <summary>
        /// Time and date of log occurence in ISO 8061 Datetime format. 
        /// </summary>
        public string TimeDateFaultEvent
        {
            get;
            set;
        }
    }
}
