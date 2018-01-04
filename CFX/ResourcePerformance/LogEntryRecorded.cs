using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
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
