using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a single event in the history of a transport order.  
    /// A transport order is a directive to move materials / WIP / production
    /// units from one location to another.
    /// </summary>
    public class TransportOrderHistory
    {
        public DateTime? EventDateTime
        {
            get;
            set;
        }
        
        /// <summary>
        /// The status of this transport order at the time of the event
        /// </summary>
        public TransportOrderStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// The operator involved in this event (optional, where applicable)
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }

        /// <summary>
        /// The location where this event took place
        /// </summary>
        public string Location
        {
            get;
            set;
        }

        /// <summary>
        /// Human readable comments related to this event (where applicable)
        /// </summary>
        public string Comments
        {
            get;
            set;
        }
    }
}
