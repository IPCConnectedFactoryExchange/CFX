using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// The status of an order to transport goods
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransportOrderStatus
    {
        /// <summary>
        /// The status is unknown
        /// </summary>
        Unspecified,
        /// <summary>
        /// The order is awaiting fulfillment
        /// </summary>
        Pending,
        /// <summary>
        /// The ordered items are being gathered and readied for transport
        /// </summary>
        Kitting,
        /// <summary>
        /// The ordered items are ready to be transported, but have not yet departed the point of origination
        /// </summary>
        Kitted,
        /// <summary>
        /// The ordered items are in transit
        /// </summary>
        InTransit,
        /// <summary>
        /// The ordered items have been delivered to their final destination
        /// </summary>
        Delivered
    }
}
