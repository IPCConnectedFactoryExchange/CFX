using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Method of testing
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TestMethod
    {
        /// <summary>
        /// The test was performed by a human being
        /// </summary>
        Human,
        /// <summary>
        /// The test was performed by automated equipment / device
        /// </summary>
        Automated
    }
}
