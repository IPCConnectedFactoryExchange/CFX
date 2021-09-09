using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// A data structure that representing a two dimensional image, in the designated MIME format.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Image ()
        {
            MimeType = "image/jpg";
            ImageData = new byte[0];
        }

        /// <summary>
        /// The MIME type of the binary image data contained by the ImageData property.
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.4 **</para>
        /// Specifies the mode of transfer.  Image data may be transferred within the CFX messages themselves (In-Band),
        /// or transferred via a separate secure protocol (Out-of-Band), such as HTTPS, SFTP, etc.
        /// Direct, in-band file transfer is not recommended for larger data files.  Many AMQP message broker platforms
        /// limit the maximum total message size of an AMQP message.  Microsoft's Azure message bus, for example, limits messages
        /// to 256KB for a standard subscription, and 1MB for a premium subscription.  RabbitMQ recommends limiting messages to 128MB or less.
        /// Use OutOfBand transfer for larger file sizes.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.4")]
        public FileTransferMode TransferMode
        {
            get;
            set;
        }

        /// <summary>
        /// If TransferMode is FileTransferMode.InBand, this property is the
        /// binary representation of the image.  Otherwise, this property should be NULL.
        /// </summary>
        public byte[] ImageData
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.4 **</para>
        /// For image transfers using FileTransferMode.OutOfBand, this property contains a secure hyperlink
        /// (URL) that may be used to download the image payload data.  Otherwise, this property should be NULL.
        /// Only encrypted, secure protocols (eg. https:// , sftp:// , etc) should be used for out of band transfers.  
        /// The CFX standard does not define any specific protcol for out of band transfers, so end-users are free to use
        /// a secure protocol of their choosing.  URL's may contain authentication information using industry
        /// standard URL formatting (eg. https://[username]:[password]@server.domain.com/DataFiles/DataFile1.json ).
        /// Other forms of authentication, such as file access tokens and keys as URL parameters, are also acceptable.
        /// CFX is flexible, and supports any encryption scheme, protocol, and authentication mechanism where all
        /// data information necessary to access the data file securely can be contained in standard URL format.
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.4")]
        public string ImageURL
        {
            get;
            set;
        }
    }
}
