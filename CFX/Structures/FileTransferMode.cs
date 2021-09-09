using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Specifies the method of file transfer.  [CLICK HERE](https://en.wikipedia.org/wiki/Out-of-band_data) for more information on transfer modes
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileTransferMode
    {
        /// <summary>
        /// Data is transfered directly within the CFX message structure / AMQP protocol channel.
        /// Direct, in-band file transfer is not recommended for larger data files.  Many AMQP message broker platforms
        /// limit the maximum total message size of an AMQP message.  Microsoft's Azure message bus, for example, limits messages
        /// to 256KB for a standard subscription, and 1MB for a premium subscription.  RabbitMQ recommends limiting messages to 128MB or less.
        /// Use OutOfBand transfer for larger file sizes.
        /// </summary>
        InBand,
        /// <summary>
        /// Data is transferred indirectly, outside the AMQP message stream, via the use of a secure URL.
        /// </summary>
        OutOfBand
    }
}
