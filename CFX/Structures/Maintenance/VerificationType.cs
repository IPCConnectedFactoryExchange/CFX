using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// An enumeration indicating the type of verification that can be executed during the process (i.e. maintenance)
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerificationType
    {
        /// <summary>
        /// Unknown verification type
        /// </summary>
        Unkwnown,
        /// <summary>
        /// General verification of the machine
        /// </summary>    
        General,
        /// <summary>
        /// Special verification, specific for a given part
        /// </summary>
        Special
    }
}
