using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX.Structures.Cleaning;

namespace CFX.Structures.SolderPastePrinting
{
    /// <summary>
    /// Describes a stencil that is used in the course of printing solder paste on to a PCB
    /// </summary>
    public class SMTStencil : Tool
    {
        /// <summary>
        /// SMT stencil cleaning states
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CleaningState CleaningState
        {
            get;
            set;
        }
    }
}
