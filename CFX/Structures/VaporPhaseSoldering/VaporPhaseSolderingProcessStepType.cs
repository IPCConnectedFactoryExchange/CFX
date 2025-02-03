using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CFX.Structures.VaporPhaseSoldering
{
    /// <summary>
    /// An enumeration indicating which type of process was executed in a vapor phase soldering machine step.
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum VaporPhaseSolderingProcessStepType
    {
        Vacuum,
        Ventilate,
        Inject
    }
}
