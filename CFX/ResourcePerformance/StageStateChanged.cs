using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when the production state of one of its
    /// stages transitions from one state to another per its state model. 
    /// <code language="none">
    /// {
    ///   "Stage": "STAGE2",
    ///   "Lane": null,
    ///   "OldState": "IdleStarved",
    ///   "OldStateDuration": "00:01:25",
    ///   "NewState": "ReadyProcessingActive",
    ///   "RelatedFault": null
    /// }
    /// </code>
    /// </summary>
    public class StageStateChanged : CFXMessage
    {
        /// <summary>
        /// The name of the stage that has changed state
        /// </summary>
        public string Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The relevant production lane (if applicable)
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

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
