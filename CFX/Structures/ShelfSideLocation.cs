using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// A Shelf side location
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShelfSideLocation
    {
        /// <summary>
        /// Unknown shelf side location
        /// </summary>
        Unknown,
        /// <summary>
        /// Front side of the shelf
        /// </summary>
        Front,
        /// <summary>
        /// Back side of the shelf
        /// </summary>
        Back
    }
}
