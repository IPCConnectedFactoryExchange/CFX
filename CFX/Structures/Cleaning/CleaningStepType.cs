using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Cleaning
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// An enumeration indicating the type of cleaning step
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CleaningStepType
    {
        /// <summary>
        /// Cleaning step pre-wash
        /// </summary>
        PreWash,
        /// <summary>
        /// Cleaning step wash
        /// </summary>    
        Wash,
        /// <summary>
        /// Cleaning step pre-rinse
        /// </summary>
        PreRinse,
        /// <summary>
        /// Cleaning step rinse
        /// </summary>
        Rinse,
        /// <summary>
        /// Cleaning step final rinse
        /// </summary>
        FinalRinse,
        /// <summary>
        /// Cleaning step dry
        /// </summary>
        Dry
    }
}
