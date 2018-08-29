using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a generic activity executed information
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ActivityExecutedInformation
    {
        /// <summary>
        /// Activity type
        /// </summary>
        public ActivityType Activity
        {
            get;
            set;
        }

        /// <summary>
        /// Activity new state
        /// </summary>
        public ActivityState State
        {
            get;
            set;
        }
    }
}
