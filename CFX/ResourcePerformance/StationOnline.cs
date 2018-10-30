using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when it is ready for communication to resume, for example, powered up, maintenance over, etc. 
    /// <code language="none">
    /// {
    ///   "OfflineDuration": "00:23:00"
    /// }
    /// </code>
    /// </summary>
    public class StationOnline : CFXMessage
    {
        /// <summary>
        /// The total amount of time the endpoint was offline prior to this notification.  Note:  There may be certain circumstances
        /// where it is impossible to provide this duration (as in the case of an unexpected power faillure or other extreme events).
        /// In this case it is acceptable to report a duration of "null", which will be interpreted as "unknown" by the receiver
        /// of this event.
        /// </summary>
        public TimeSpan? OfflineDuration
        {
            get;
            set;
        }
    }
}
