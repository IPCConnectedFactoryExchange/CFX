using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when the production state transitions
    /// from one state to another per its state model. 
    /// <para>Example 1 (State change with no related fault):</para>
    /// <code language="none">
    /// {
    ///   "OldState": "IdleStarved",
    ///   "OldStateDuration": "00:01:25",
    ///   "NewState": "ReadyProcessingActive",
    ///   "RelatedFault": null
    /// }
    /// </code>
    /// <para>Example 2 (State change with related fault):</para>
    /// <code language="none">
    /// {
    ///   "OldState": "ReadyProcessingExecuting",
    ///   "OldStateDuration": "00:00:25",
    ///   "NewState": "UnplannedDowntime",
    ///   "RelatedFault": {
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "84c6021f-9db9-431b-aa0b-567b961ac96f",
    ///     "Lane": null,
    ///     "Stage": null
    ///   }
    /// }
    /// </code>
    /// </summary>
    public class StationStateChanged : CFXMessage
    {
        /// <summary>
        /// The previous state prior to this state change
        /// </summary>
        public ResourceState OldState
        {
            get;
            set;
        }

        /// <summary>
        /// The amount of time spent in the previous state
        /// </summary>
        public TimeSpan OldStateDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The new state
        /// </summary>
        public ResourceState NewState
        {
            get;
            set;
        }

        /// <summary>
        /// In the case of a stoppage, information about the Fault which caused the stoppage.
        /// Otherwise null.
        /// </summary>
        public Fault RelatedFault
        {
            get;
            set;
        }
    }
}
