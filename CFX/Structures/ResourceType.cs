using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// Describes a resource type
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceType
    {
        /// <summary>
        /// Unknown resource type
        /// </summary>
        Unknown,
        /// <summary>
        /// The resource is a machine, also known as a "process endpoint"
        /// </summary>
        Machine,
        /// <summary>
        /// The resource is a shelf, with no intelligence
        /// </summary>
        Shelf,
        /// <summary>
        /// The resource is a storage tower, with a potential intelligence and a specific way of classifying materials
        /// </summary>
        StorageTower,
        /// <summary>
        /// The resource is a setup station (typically a PC with material programming capabilities)
        /// </summary>
        SetupStation,
        /// <summary>
        /// The resource is a storage room
        /// </summary>
        StorageRoom,
        /// <summary>
        /// The resource is a waiting area, i.e a setup area
        /// </summary>
        WaitingArea
    }
}
