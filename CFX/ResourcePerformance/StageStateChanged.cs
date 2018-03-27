using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when its production state transitions from
    /// one state to another per its state model. 
/// </summary>
public class StageStateChanged : CFXMessage
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
