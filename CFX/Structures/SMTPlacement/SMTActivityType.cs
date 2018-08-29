using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The type of activity for an SMT machine
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTActivityType
    {
        /// <summary>
        /// Board loading
        /// </summary>
        BoardLoading,
        /// <summary>
        /// Board unloading
        /// </summary>
        BoardUnloading,
        /// <summary>
        /// Board alignment
        /// </summary>
        BoardAlignment,
        /// <summary>
        /// Feeder configuration
        /// </summary>
        FeederConfiguration,
        /// <summary>
        /// Nozzle Change
        /// </summary>
        NozzleChange,
        /// <summary>
        /// Head Change
        /// </summary>
        HeadChange,
        /// <summary>
        /// Placement
        /// </summary>
        Placement
    }
}
