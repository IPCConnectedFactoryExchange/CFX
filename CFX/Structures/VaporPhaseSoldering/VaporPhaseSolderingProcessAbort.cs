namespace CFX.Structures.VaporPhaseSoldering
{
    /// <summary>
    /// Vapor Phase Soldering Process Abort
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class VaporPhaseSolderingProcessAbort
    {
        public bool IsAborted
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }
    }
}
