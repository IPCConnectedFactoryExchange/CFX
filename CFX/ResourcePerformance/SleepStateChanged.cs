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
    /// Sent by a process endpoint when the sleep state transitions
    /// from one state to another. 
    /// <para>Example 1 (Sleep State change to deeper sleep state):</para>
    /// <code language="none">
    /// {
    ///   "OldSleepState": "Awake",
    ///   "NewSleepState": "Shallow",
    ///   "TransitionTimeRemaining": 0
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
    ///   "TransitionTimeRemaining": 45
    /// }
    /// </code>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SleepStateChanged : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SleepStateChanged()
        {
            OldSleepState = SleepType.Awake;
            NewSleepState = SleepType.Awake;
        }

        /// <summary>
        /// An enumeration indicating the previous sleep state prior to this state change
        /// </summary>
        [JsonProperty]
        public SleepType OldSleepState
        {
            get;
            set;
        }

        /// <summary>
        /// The new sleep state
        /// </summary>
        [JsonProperty]
        public SleepType NewSleepState
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
        /// Units are in seconds.
        /// </summary>
        [JsonProperty]
        public int TransitionTimeRemaining
        {
            get;
            set;
        }
    }
}