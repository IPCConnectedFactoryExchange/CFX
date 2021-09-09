using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Specifies the mode of file transfer.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileTransferDirection
    {
        /// <summary>
        /// Data transfer will proceed from the initiator of the request (the source) to the receiver of the request (the destination).
        /// In this mode, the file information is contained within the request itself.
        /// </summary>
        Push,
        /// <summary>
        /// Data is transfer will proceed from the receiver of the request (the source) to the initiator of the request (the destination).
        /// In this mode, the file information is contained within the response message.
        /// </summary>
        Pull
    }
}
