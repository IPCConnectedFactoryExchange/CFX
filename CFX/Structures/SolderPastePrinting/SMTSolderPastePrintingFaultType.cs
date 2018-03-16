using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// Types of SMT printing faults
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTSolderPastePrintingFaultType
    {
        /// <summary>
        /// A squeegee related error
        /// </summary>
        SqueegeeError,
        /// <summary>
        /// A paste related error
        /// </summary>
        PasteError,
    }
}
