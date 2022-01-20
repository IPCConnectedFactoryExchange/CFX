using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Specifies the type of a file.  
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        /// <summary>
        /// Specifies a file that is of a known MIME content-type, such as text, XML, JSON, a variety of images types like JPEG, PNG, etc., etc.
        /// To learn more about MIME content types, [CLICK HERE](https://en.wikipedia.org/wiki/Media_type).
        /// </summary>
        GenericMimeType,
        /// <summary>
        /// Specifies an IPC-2581 formatted DPMX file.
        /// </summary>
        DPMX
    }
}
