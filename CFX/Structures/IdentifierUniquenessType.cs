using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// An enumeration indicating the type of unique identifier for the specified endpoint / resource / sub-resource
    /// Values: GloballyPersistent, LocallyPersistent, UnserializedLocation or Unknown
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdentiferUniquenessType
    {
        /// <summary>
        /// Unknown: no fixed relationship with a physical object 
        /// </summary>
        Unkwnown,
        /// <summary>
        /// Globally valid: it follows the resource in its whole lifecycle (i.e. across all machines)
        /// </summary>    
        GloballyPersistent,
        /// <summary>
        /// Locally valid: it stays constant as long as the resource is in the current machine (i.e. it may change when in another)
        /// </summary>    
        LocallyPersistent,
        /// <summary>
        /// No identifier for the given location
        /// </summary>
        UnserializedLocation
       
    }
}
