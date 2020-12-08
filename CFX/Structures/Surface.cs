using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// For use two-dimensional production (as in the case of PCBA production).  Identifies the surface of the unit
    /// under production (product) that is relevant for a given process or situation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("1.3")]
    public enum Surface
    {
        /// <summary>
        /// The relevant surface has not been specified
        /// </summary>
        Unspecified,
        /// <summary>
        /// The primary surface of the product is relevant
        /// </summary>
        PrimarySurface,
        /// <summary>
        /// The secondary surface is relevant
        /// </summary>
        SecondarySurace
    }
}
