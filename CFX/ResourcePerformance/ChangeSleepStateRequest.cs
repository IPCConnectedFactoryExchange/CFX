using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// This request allows an external source to change the sleep state of a Stage or Station
    /// <see cref="ChangeSleepStateResponse"/> message that it sends back to the requester.
    /// <code language="none">
    /// {
    ///   "StageName": "Stage 1",
    ///   "NewSleepState": "Awake"
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ChangeSleepStateRequest : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChangeSleepStateRequest()
        {
        }

        /// <summary>
        /// Name of the Stage requested to change sleep state.
        /// If omitted then the sleep state for the whole station is to be changed.
        /// </summary>
        public string StageName
        {
            get;
            set;
        }

        /// <summary>
        /// The new sleep state requested for the Stage/Station
        /// </summary>
        public SleepType NewSleepState
        {
            get;
            set;
        }

    }
}