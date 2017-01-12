using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Events.WorkCenterServices
{
    /// <summary>
    /// Indicates that the current state of a production station has changed (based
    /// on the CFX equipment state model).
    /// </summary>
    public class WorkCenterStateChange
    {
        /// <summary>
        /// The new state of the production station.
        /// </summary>
        public StationState NewState
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
        Unknown = 0,
        
        /// <summary>
        /// The station is being setup, and is not in production.
        /// </summary>
        Setup = 1,
        
        /// <summary>
        /// The station is in production, but is idle because there are no production units
        /// available for processing.
        /// </summary>
        IdleStarved = 2,

        /// <summary>
        /// The station is in production, but is idle because the station is blocked by a 
        /// downstream condition, and cannot move production units downstream.
        /// </summary>
        IdleBlocked = 3,

        /// <summary>
        /// The station is in production, and actively proecessing a production unit.
        /// </summary>
        Executing = 4,

        /// <summary>
        /// The station is in production, but has been halted by an error condition or fault.
        /// </summary>
        Down = 5
    }



}
