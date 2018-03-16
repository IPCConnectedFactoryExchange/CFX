using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Types of Operators
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActorType
    {
        /// <summary>
        /// A human being is performing the operation
        /// </summary>
        Human,
        /// <summary>
        /// A robotic / automated device is performing the operation
        /// </summary>
        Robot
    }
}
