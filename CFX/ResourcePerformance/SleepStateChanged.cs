using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;
using CFX.Utilities;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Sent by a process endpoint when the sleep state transitions
    /// from one state to another. 
    /// <para>Example 1 (Sleep State change to deeper sleep state):</para>
    /// <code language="none">
    /// {
    ///   "OldSleepState": "Awake",
    ///   "NewSleepState": "Shallow",
    ///   "TransitionTimeRemaining": null
    /// }
    /// </code>
    /// <para></para>
    /// <para>Example 2 (Sleep State change to shallower sleep state):</para>
    /// <code language="none">
    /// {
    ///   "OldSleepState": "Hibernate",
    ///   "NewSleepState": "Awake", 
    ///   "Stage": {
    ///     "StageSequence": 2,
    ///     "StageName": "Stage 1",
    ///     "StageType": "Work"
    ///   },
    ///   "Lane": null,    
    ///   "TransitionTimeRemaining": "00:00:45"
    /// }
    /// </code>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [CFX.Utilities.CreatedVersion("1.3")]
    public class SleepStateChanged : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SleepStateChanged()
        {
            OldSleepState = "Awake";
            NewSleepState = "Awake";
        }

        /// <summary>
        /// An enumeration indicating the previous sleep state prior to this state change
        /// </summary>
        [JsonProperty]
        public string OldSleepState
        {
            get;
            set;
        }

        /// <summary>
        /// The new sleep state
        /// </summary>
        [JsonProperty]
        public string NewSleepState
        {
            get;
            set;
        }


        /// <summary>
        /// The stage that has changed sleep state. If omitted then the sleep state for the whole station has been changed.
        /// </summary>
        [JsonProperty]
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The relevant production lane (if applicable)
        /// </summary>
        [JsonProperty]
        public int? Lane
        {
            get;
            set;
        }

        /// <summary>
        /// If the new sleep state requires less wake up time than the old, this indicates that the state is in the process of being changed.
        /// Time interval can be nullable (for example if there is no time remaining).
        /// </summary>
        [JsonProperty]
        public TimeSpan? TransitionTimeRemaining
        {
            get;
            set;
        }
    }
}