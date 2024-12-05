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
        /// Clean mode W - wet clean: printer uses a cleaning liquid to wipe the stencil
        /// </summary>
        W,
        /// <summary>
        /// Clean mode V - vacuum clean: printer is using vacuum cleaner to dry up the cleaning liquid or to
		/// support the cleaning strokes
        /// </summary>
        V,
        /// <summary>
        /// Clean mode D - dry clean: printer wipes the stencil with a dry fabric
        /// </summary>
        D
    }
}
