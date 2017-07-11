using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Events
{
    /// <summary>
    /// Indicates that the current state of a production station has changed (based
    /// on the CFX equipment state model).
    /// </summary>
    [DataContract]  
    public class WorkCenterStateChange
    {
        /// <summary>
        /// The new state of the production station.
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public StationState NewState
        {
            get;
            set;
        }

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public StationState OldState
        {
            get;
            set;
        }
    }

    /// <summary>
    /// An enumeration indication the current state of a production station.
    /// </summary>
    public enum StationState
    {
        /// <summary>
        /// The state of the station is unknown
        /// </summary>
        Unknown,
        
        /// <summary>
        /// The station is being setup, and is not in production.
        /// </summary>
        Setup,
        
        /// <summary>
        /// The station is in production, but is idle because there are no production units
        /// available for processing.
        /// </summary>
        IdleStarved,

        /// <summary>
        /// The station is in production, but is idle because the station is blocked by a 
        /// downstream condition, and cannot move production units downstream.
        /// </summary>
        IdleBlocked,

        /// <summary>
        /// The station is in production, and actively proecessing a production unit.
        /// </summary>
        Executing,

        /// <summary>
        /// The station is in production, but has been halted by an error condition or fault.
        /// </summary>
        Down
    }



}
