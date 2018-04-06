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
        /// The total amount of time the endpoint was offline prior to this notification.
        /// </summary>
        public TimeSpan OfflineDuration
        {
            get;
            set;
        }
    }
}
