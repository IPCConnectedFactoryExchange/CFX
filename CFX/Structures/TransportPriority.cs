using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Enum that specifies the priority of the transport.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public enum TransportPriority
    {
        ///<summary>
        ///Priority of transport request is low
        ///</summary>
        Low,
        ///<summary>
        ///Priority of transport request is medium
        ///</summary>
        Medium,
        ///<summary>
        /// Priority of transport request is high
        ///</summary>
        High
    }
}
