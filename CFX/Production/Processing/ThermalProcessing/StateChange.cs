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
		"TimeDateFaultEvent": " 20080915T155300",
		"Message": "VPSTART",
		"RecipeName": "Recipe001"
	}

	*/
    /// </code>
    /// </summary>
    public class SimulatedProfilingStateChange : CFXMessage
    {
        /// <summary>
        /// updated on StateChange of ThermalProcessing endpoint
        /// </summary>
        public ThermalProcessingState StateChange
        {
            get;
            set;
        }
    }
}
