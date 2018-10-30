using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the reason why a production units was disqualified (scrapped)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DisqualificationReason
    {
        /// <summary>
        /// The unit is defective and cannot be repaired.
        /// </summary>
        DefectiveRepairNotPossible,
        /// <summary>
        /// The unit is defective, and a repair is not feasible (for economic or business reasons)
        /// </summary>
        DefectiveRepairNotFeasible,
        /// <summary>
        /// The unit contains defective materials.
        /// </summary>
        DefectiveMaterials,
    }
}
