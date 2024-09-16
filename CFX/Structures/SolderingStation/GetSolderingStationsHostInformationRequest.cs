namespace CFX
{
    /// <summary>
    /// Requests detailed information about a single endpoint, as specified by its CFX Handle.
    /// The response includes information regarding the endpoint’s capabilities
    /// <code language="none">
    /// {
    ///   "CFXHandle": "SolderingPCHost.Model1.001"
    /// }
    /// </code>
    /// </summary>
    public class GetSolderingStationsHostInformationRequest : CFXMessage
    {
        /// <summary>
        /// The handle of the endpoint about which the sender wishes to obtain information.
        /// </summary>
        public string CFXHandle
        {
            get;
            set;
        }
    }
}
