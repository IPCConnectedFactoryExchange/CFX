using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.Processing.ThermalProcessing
{
    /// <summary>
    /// Sent by a process endpoint after a state change.
    /// <code language="none">
	  /*
    {
      "$type": "CFX.Structures.SimulatedProfiling.SimulatedProfilingLog, CFX",
      "TimeDateFaultEvent": "20080915T155312",
      "Cause": “PROCESSGOINGOUTOFSPEC”,
      "Severity": "INFORMATION",
      "FaultCode": null,
      "FaultOccurrenceId": null,
      "Lane": null,
      "Stage": null
    }
	  */
    /// </code>
    /// </summary>
    public class SimulatedProfilingStateChange : CFXMessage
    {
        /// <summary>
        /// updated when ThermalProcessing endpoint has a new log entry
        /// </summary>
        public LogEntry LogEntryRecorded
        {
            get;
            set;
        }
    }
}
