using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Dynamic structure base class for current process state and time stamp.
    /// <code language="none">
    /// {
    ///     "CoatingActiviy" : "System Pressure Test",
    ///     "ElaspedTime" : "0 00:00:10",
    ///     "TimeStamp" : "2018-10-25T08:46:46.5300797-04:00"
    /// }
    /// </code>
    /// </summary>
    public class CoatingActivity
    {
        /// <summary>
        /// Current coating process activity.
        /// </summary>
        public String Activity
        {
            get; 
            set;
        }

        /// <summary>
        /// Elasped time since process start.
        /// </summary>
        public string ElaspedTime
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the activity transitioned to the state specified by the
        /// ActivityState property.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            set;
        }
    }
}
