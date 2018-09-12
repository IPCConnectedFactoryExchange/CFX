using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// An enumeration indicating different types of stages that might exist at an endpoint.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StageType
    {
        /// <summary>
        /// Work on production units is performed at this stage.  This may be any sort of work, including assembly, inspection, processing, etc.
        /// </summary>
        Work,
        /// <summary>
        /// This stage is intended to serve as a buffer for production units.  No work is performed at this stage.
        /// </summary>
        Buffer,
    }
}
