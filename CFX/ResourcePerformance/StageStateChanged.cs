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
    /// Sent by a process endpoint when the production state of one of its
    /// stages transitions from one state to another per its state model. 
    /// <code language="none">
    /// {
    ///   "Stage": {
    ///     "StageSequence": 2,
    ///     "StageName": "STAGE2",
    ///     "StageType": "Work"
    ///   },
    ///   "Lane": null,
    ///   "OldState": 2200,
    ///   "OldStateDuration": "00:01:25",
    ///   "NewState": 1100,
    ///   "RelatedFault": null
    /// }
    /// </code>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class StageStateChanged : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StageStateChanged()
        {
            OldState = StateConverter.DefaultResourceState;
            NewState = StateConverter.DefaultResourceState;
        }

        /// <summary>
        /// The name of the stage that has changed state
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
        /// The previous state prior to this state change
        /// </summary>
        [JsonProperty]
        public ResourceState OldState
        {
            get;
            set;
        }

        /// <summary>
        /// Exposes vendor specific old state code (like 3312, for example) as its equivalent
        /// Semi E58 enumerated value.
        /// READ-ONLY HELPER PROPERTY, NOT A DATA PROPERTY.  WILL NOT APPEAR IN JSON DATA.
        /// </summary>
        public ResourceState OldE58State
        {
            get
            {
                return StateConverter.GetSemiE58State(OldState);
            }
        }

        /// <summary>
        /// The amount of time spent in the previous state.  Note:  There may be certain circumstances
        /// where it is impossible to provide this duration (as in the case of an unexpected power faillure or other extreme events).
        /// In this case it is acceptable to report a duration of "null", which will be interpreted as "unknown" by the receiver
        /// of this event.
        /// </summary>
        [JsonProperty]
        public TimeSpan? OldStateDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The new state
        /// </summary>
        [JsonProperty]
        public ResourceState NewState
        {
            get;
            set;
        }

        /// <summary>
        /// Exposes vendor specific new state code (like 3312, for example), as its equivalent
        /// Semi E58 enumerated value.
        /// READ-ONLY HELPER PROPERTY, NOT A DATA PROPERTY.  WILL NOT APPEAR IN JSON DATA.
        /// </summary>
        public ResourceState NewE58State
        {
            get
            {
                return StateConverter.GetSemiE58State(OldState);
            }
        }

        /// <summary>
        /// In the case of a stoppage, information about the Fault which caused the stoppage.
        /// Otherwise null.
        /// </summary>
        [JsonProperty]
        public Fault RelatedFault
        {
            get;
            set;
        }
    }
}
