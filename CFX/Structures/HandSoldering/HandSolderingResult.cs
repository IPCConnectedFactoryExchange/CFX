namespace CFX.Structures.HandSoldering
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// An enumeration of hand soldering results. 
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum HandSolderingResult
    {
        Undefined = 0,
        Success = 1,
        Failed = 2,
        Ignore = 3,
        ToVerifyAgain = 4,
        Rework = 5
    }
}