using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// Modes of stencil cleaning
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTStencilCleanMode
    {
        /// <summary>
        /// Clean mode W
        /// </summary>
        W,
        /// <summary>
        /// Clean mode V
        /// </summary>
        V,
        /// <summary>
        /// Clean mode D
        /// </summary>
        D
    }
}
