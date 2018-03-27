using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// An informational message sent by a process endpoint regarding the something that has occurred at the station. 
    /// Information about the criticality of the information should also be given (information, warning, error etc.)
    /// </summary>
    public class LogEntryRecorded : CFXMessage
    {
        public LogEntryRecorded()
        {
            Importance = LogImportance.Information;
        }

        public string InformationId
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public LogImportance Importance
        {
            get;
            set;
        }

        public string Lane
        {
            get;
            set;
        }

        public string Stage
        {
            get;
            set;
        }
    }
}
