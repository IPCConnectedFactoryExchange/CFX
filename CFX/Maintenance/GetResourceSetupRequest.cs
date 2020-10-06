using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Maintenance
{
    /// <summary>
    /// Requests detailed resource setup information about a single endpoint, as specified by its CFX Handle.
    /// The response includes information regarding the endpoint’s resource and sub-resources setup
    /// that may undergo maintenance operations
    /// <code language="none">
    /// {
    ///   "CFXHandle": "SMT.SIPLACE_SX4.10000000"
    /// }
    /// </code>
    /// </summary>
    public class GetResourceSetupRequest : CFXMessage
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
