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
        Automated,
        /// <summary>
        /// The test was performed by an in-circuit test equipment / device
        /// </summary>
        ICT,
        /// <summary>
        /// The test was performed by a flying probe test machine / equipment / device
        /// </summary>
        FPT,
        /// <summary>
        /// The test was performed by a functional test machine / equipment / device
        /// </summary>
        FCT,
        /// <summary>
        /// The test was performed by a boundary scan test machine / equipment / deivce
        /// </summary>
        BST
    }
}
