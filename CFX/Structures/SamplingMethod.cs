using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a particular sampling methodology.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SamplingMethod
    {
        /// <summary>
        /// No sampling.  All units are inspected (100% Inspection).
        /// </summary>
        NoSampling,
        /// <summary>
        /// Units sampled according to ANSI/ASQ Z1.4 AQL methods.
        /// </summary>
        ANSI_Z14,
        /// <summary>
        /// Units sampled according to MIL-STD-105 mil standard.
        /// </summary>
        MIL_STD_105,
        /// <summary>
        /// Units sampled according to MIL-STD-1916 mil standard.
        /// </summary>
        MIL_STD_1916,
        /// <summary>
        /// Units sampled according to the Squeglia AQL method.
        /// </summary>
        Squeglia,
        /// <summary>
        /// A fixed number of units were sampled (lot size disregarded).
        /// </summary>
        FixedSample
    }
}
