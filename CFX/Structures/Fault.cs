using System;
using System.Collections.Generic;
using System.Text;

namespace CFX
{
    public class Fault
    {
        public Fault()
        {
            Cause = FaultCause.MechanicalFailure;
            Severity = FaultSeverity.Information;
            FaultOccurrenceId = Guid.NewGuid();
        }

        public FaultCause Cause
        {
            get;
            set;
        }

        public FaultSeverity Severity
        {
            get;
            set;
        }

        public string FaultCode
        {
            get;
            set;
        }

        public Guid FaultOccurrenceId
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
