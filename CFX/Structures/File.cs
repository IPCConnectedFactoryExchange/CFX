using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// A data structure that represents a data file of any type.
    /// The file may be of a known MIME type, or a specialized type defined by CFX (like IPC-2581 / DPMX, for example).
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class File
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public File()
        {
        }

        /// <summary>
        /// An enumeration that descibes the type of file to be transferred.  This may be a generic, well-known file format
        /// (MIME content types), or a specialized format defined specifically by the CFX standard, such as an IPC-2581 DPMX
        /// design file.
        /// </summary>
        public FileType FileType
        {
            get;
            set;
        }

        /// <summary>
        /// For data files of type FileType.GenericMimeType, this property specifies the MIME content-type.
        /// For other file types, such as IPC-2581 DPMX, this property should be NULL.
        /// To learn more about MIME content types, [CLICK HERE](https://en.wikipedia.org/wiki/Media_type)
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// For file tokens of type FileTransferMode.InBand, this property contains the binary file payload data.
        /// For FileTransferMode.OutOfBand, this property should be NULL.
        /// </summary>
        public byte[] FileData
        {
            get;
            set;
        }

        /// <summary>
        /// For transfers using type FileTransferMode.OutOfBand, this property contains a secure hyperlink
        /// (URL) that may be used to download the file payload data.  Only encrypted, secure protocols,
        /// (eg. https:// , sftp:// , etc) should be used for out of band transfers.  The CFX standard
        /// does not define any specific protcol for out of band transfers, so end-users are free to use
        /// a secure protocol of their choosing.  URL's may contain authentication information using industry
        /// standard URL formatting (eg. https://[username]:[password]@server.domain.com/DataFiles/DataFile1.json ).
        /// Other forms of authentication, such as file access tokens and keys as URL parameters, are also acceptable.
        /// CFX is flexible, and supports any encryption scheme, protocol, and authentication mechanism where all
        /// data information necessary to access the data file securely can be contained in standard URL format.
        /// </summary>
        public string FileURL
        {
            get;
            set;
        }
    }
}
