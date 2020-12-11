using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Maintenance
{
    /// <summary>
    /// Requests detailed resource maintenance information about a single endpoint, as specified by its CFX Handle.
    /// The response includes information regarding the endpoint’s maintenance, counters, errors, verification
    /// that are relevant for the decisions around the execution of the maintenance operations  
    /// <code language="none">
    /// {
    ///   "CFXHandle": "SMT.SIPLACE_SX4.10000000"
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class GetResourceMaintenanceAndServiceRequest : CFXMessage
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
