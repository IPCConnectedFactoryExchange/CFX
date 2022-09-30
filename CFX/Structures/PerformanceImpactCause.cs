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
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// Possible causes of lower-than-expected performance, which a machine may be able to report as performance impacts
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PerformanceImpactCause
    {
        /// <summary>
        /// An alternative track was used for component pick-up
        /// </summary>
        AlternativeTrackUsed,
        /// <summary>
        /// A segment on a head was deactivated
        /// </summary>
        DeactivatedSegmentOnHead,
        /// <summary>
        /// Option “Dump Always” activated for vision system
        /// </summary>
        VisionSystemDumpAlwaysActivated,
        /// <summary>
        /// Vision system had to acquire additional images
        /// </summary>
        AdditionalImageAcquisition,
        /// <summary>
        /// Feeder speed is lower than expected
        /// </summary>
        LowFeederSpeed,
        /// <summary>
        /// Gang pick head cannot pick in parallel
        /// </summary>
        GangPickNoParallelPick
    }
}
