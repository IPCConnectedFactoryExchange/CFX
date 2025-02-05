using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.VaporPhaseSoldering
{
    /// <summary>
    /// An enumeration indicating whether the vapor phase soldering process step was executeded sucessfully.
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]

    public enum VaporPhaseSolderingProcessStepState
    {
        Success,
        Failed,
        Warning,
        Inactive
    }
}
