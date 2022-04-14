using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// The status condition of a Unit.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UnitStatus
    {
        /// <summary>
        /// The production unit has completed all prior operations without defects, or with all defects resolved
        /// </summary>
        Pass,
        /// <summary>
        /// The production unit has not passed the preceding operation, though may be recoverable
        /// </summary>
        Fail,
        /// <summary>
        /// The production unit has not passed the preceding operation, and has been deemed unrepairable
        /// </summary>
        Scrap
    }
}
