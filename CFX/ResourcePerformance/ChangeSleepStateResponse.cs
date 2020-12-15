using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Response to an external source to modify a generic configuration parameter of a process endpoint.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
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
    [CFX.Utilities.CreatedVersion("1.3")]
    public class ChangeSleepStateResponse : CFXMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeSleepStateResponse"/> class.
        /// </summary>
        public ChangeSleepStateResponse()
        {
            Result = new RequestResult();
            OldSleepState = "Awake";
            NewSleepState = "Awake";
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
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