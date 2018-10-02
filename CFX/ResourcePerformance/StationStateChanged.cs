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
    /// Sent by a process endpoint when the production state transitions
    /// from one state to another per its state model. 
    /// <para>Example 1 (State change with no related fault):</para>
    /// <code language="none">
    /// {
    ///   "OldState": 2200,
    ///   "OldStateDuration": "00:01:25",
    ///   "NewState": 1100,
    ///   "RelatedFault": null
    /// }
    /// </code>
    /// <para></para>
    /// <para>Example 2 (State change with related fault):</para>
    /// <code language="none">
    /// {
    ///   "OldState": 1100,
    ///   "OldStateDuration": "00:00:25",
    ///   "NewState": 5500,
    ///   "RelatedFault": {
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "3de0cfce-42f4-4302-982b-96dba4ec3de0",
    ///     "Lane": null,
    ///     "Stage": null,
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown"
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class StationStateChanged : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StationStateChanged()
        {
            OldState = StateConverter.DefaultResourceState;
            NewState = StateConverter.DefaultResourceState;
        }

        /// <summary>
        /// An enumeration indicating the previous state prior to this state change
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
        /// The amount of time spent in the previous state
        /// </summary>
        [JsonProperty]
        public TimeSpan OldStateDuration
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
