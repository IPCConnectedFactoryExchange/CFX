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
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// The result of a repair
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RepairResult
    {
        /// <summary>
        /// The repair was performed successfully
        /// </summary>
        RepairSuccessful,
        /// <summary>
        /// The repair was not able to be completed
        /// </summary>
        UnableToRepair,
        /// <summary>
        /// It is not possible to repair the unit, and the unit must be scrapped
        /// </summary>
        Scrap,
        /// <summary>
        /// The repair could not be completed because an error occurred
        /// </summary>
        Error,
        /// <summary>
        /// The repair was aborted by the operator / user
        /// </summary>
        Aborted
    }
}
