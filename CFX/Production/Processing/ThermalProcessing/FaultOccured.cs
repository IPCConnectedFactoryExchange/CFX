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
	"$type": "CFX.Structures.SimulatedProfiling.SimulatedProfilingFault, CFX",
	"TimeDateFaultEvent": "20080915T155312",
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
    public class SimulatedProfilingFaultOccured : CFXMessage
    {
        /// <summary>
        /// Fault state of thermal processing endpoint
        /// </summary>
        public FaultState FaultOccured
        {
            get;
            set;
        }
    }
}
