using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// A request to an endpoint (such as an upper level system, MES, ERP, etc.) to check
    /// the status of a particular transport order.  A transport order is a directive to move
    /// materials / WIP / production units from one location to another.
    /// <code language="none">
    /// {
    ///   "TransportOrderNumber": "TR329483249830000"
    /// }
    /// </code>
    /// </summary>
    public class GetTransportOrderStatusRequest : CFXMessage
    {
        /// <summary>
        /// The order number of the related transport order
        /// </summary>
        public string TransportOrderNumber
        {
            get;
            set;
        }
    }
}
