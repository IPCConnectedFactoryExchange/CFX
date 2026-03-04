namespace CFX.Structures.VaporPhaseSoldering
{

    /// <summary>
    /// An enumeration indicating which type of process was executed in a vapor phase soldering machine step.
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum VaporPhaseSolderingProcessStepType
    {
        Vacuum,
        Vent,
        Inject,
        Exhaust
    }
}
