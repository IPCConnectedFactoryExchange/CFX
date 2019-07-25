using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the state of an activity.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActivityState
    {
        /// <summary>
        /// The activity has started, but is not yet complete.
        /// </summary>
        Started,
        /// <summary>
        /// The activity was aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// The activity successfullly completed.
        /// </summary>
        Completed,
        /// <summary>
        /// The item/activity has switched ON
        /// </summary>
        On,
        /// <summary>
        /// The item/activity has switched OFF
        /// </summary>
        Off
    }
}
