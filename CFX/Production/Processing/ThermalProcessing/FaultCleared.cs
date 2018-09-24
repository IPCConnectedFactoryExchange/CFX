using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.Processing.ThermalProcessing
{
    /// <summary>
    /// Sent by a process endpoint after a fault occurs.
    /// <code language="none">
    /*
    {
      "$type":      "CFX.Structures.SimulatedProfiling.SimulatedProfilingFaultCleared, CFX",
      "TimeDateFaultClear": "20080915T155312",
      "Cause": “PROCESSOUTOFSPEC”,
      "Severity": "WARNING",
      "FaultCode": null,
      "FaultOccurrenceId": null,
      "Lane": null,
      "Stage": null
    }
    */
    /// </code>
    /// </summary>
    public class SimulatedProfilingFaultCleared : CFXMessage
    {
        /// <summary>
        /// updated when fault is cleared at Thermal Processing endpoint
        /// </summary>
        public FaultClear FaultCleared
        {
            get;
            set;
        }
    }
}
