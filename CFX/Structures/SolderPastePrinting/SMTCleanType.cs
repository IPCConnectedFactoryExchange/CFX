using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// Types of SMT stencil cleans
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTCleanType
    {
        /// <summary>
        /// A typical clean
        /// </summary>
        Normal,
        /// <summary>
        /// A more involved, deeper clean
        /// </summary>
        Deep,
        /// <summary>
        /// A fast, light clean
        /// </summary>
        Quick
    }
}
