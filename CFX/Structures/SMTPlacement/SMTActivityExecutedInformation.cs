using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes an activity executed information for an SMT machine
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class SMTActivityExecutedInformation : ActivityExecutedInformation
    {
        /// <summary>
        /// SMT activity type
        /// </summary>
        new public SMTActivityType Activity
        {
            get;
            set;
        }
    }
}
