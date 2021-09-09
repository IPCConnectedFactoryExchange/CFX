using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;
using CFX.Structures;

namespace CFX.InformationSystem.DataTransfer
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Sent by an endpoint in response to a <see cref="FileTransferRequest"/>.  File transfers may proceed either from the initiater/requester
    /// to the recipient (PUSH Mode), OR from recipient to initiater/requester (PULL Mode).  File transfers may also may also be "In-Band", 
    /// meaning that the file data payload is included in the CFX message directly and transferred via the AMQP protocol.  OR, they may
    /// be "Out-of-Band", meaning that a secure link to the data file is passed via the CFX message over AMQP protocol, and a secondary
    /// protocol (such as HTTPS or SFTP) is then used to transfer the file data payload, independent of the AMQP message stream.  When in PUSH
    /// mode, the <see cref="FileTransferRequest"/> will either contain the In-Band file data payload, or an Out-Of-Band secure link.  When in PULL mode, 
    /// the <see cref="FileTransferResponse"/> will contain the In-Band file data payload, or an Out-Of-Band secure link.
    /// <para></para>
    /// In-Band file transfers should only be used for small data files.  Many AMQP message broker platforms
    /// limit the maximum total message size of an AMQP message.  Microsoft's Azure message bus, for example, limits messages
    /// to 256KB for a standard subscription, and 1MB for a premium subscription.  RabbitMQ recommends limiting messages to 128MB or less.
    /// Use OutOfBand transfer for larger file sizes.
    /// <para></para>
    /// <para>Out-of-Band PULL Example:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "FileTitle": "IPC_2581_DPMX_DesignData_Example1.xml",
    ///   "FileLocation": "\\DesignDataRoot\\Folder1",
    ///   "TransferDirection": "Pull",
    ///   "TransferMode": "OutOfBand",
    ///   "File": null
    /// }
    /// </code>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "FileTitle": "IPC_2581_DPMX_DesignData_Example1.xml",
    ///   "FileLocation": "\\DesignDataRoot\\Folder1",
    ///   "TransferMode": "OutOfBand",
    ///   "File": {
    ///     "FileType": "DPMX",
    ///     "MimeType": null,
    ///     "FileData": null,
    ///     "FileURL": "https://jsmith:Pa$$w0rd@designserver1.mydomain.com"
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// <para>Out-of-Band PUSH Example:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "FileTitle": "IPC_2581_DPMX_DesignData_Example1.xml",
    ///   "FileLocation": "\\DesignDataRoot\\Folder1",
    ///   "TransferDirection": "Push",
    ///   "TransferMode": "OutOfBand",
    ///   "File": {
    ///     "FileType": "DPMX",
    ///     "MimeType": null,
    ///     "FileData": null,
    ///     "FileURL": "https://jsmith:Pa$$w0rd@designserver1.mydomain.com"
    ///   }
    /// }
    /// </code>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "OK"
    ///   },
    ///   "FileTitle": "IPC_2581_DPMX_DesignData_Example1.xml",
    ///   "FileLocation": "\\DesignDataRoot\\Folder1",
    ///   "TransferMode": "OutOfBand",
    ///   "File": null
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class FileTransferResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public FileTransferResponse()
        {
        }

        /// <summary>
        /// Result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// The title of the file, EXCLUDING any path information, but INCLUDING file extension when appropriate.
        /// </summary>
        public string FileTitle
        {
            get;
            set;
        }

        /// <summary>
        /// An optional property that may be used to indicate the location to the file on the source system.  This need not be a physical path.
        /// It could be as virtual path, as in the case of a web or FTP server, or file share.  Alternatively, it need not represent a traditional
        /// path at all.  For example, it could be a lookup key to locate the file within a NoSQL database environment.  The format of this property
        /// is dependent on the nature of the source system.
        /// </summary>
        public string FileLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the mode of transfer.  File data may be transferred within the CFX messages themselves (In-Band),
        /// or transferred via a separate secure protocol (Out-of-Band), such as HTTPS, SFTP, etc.
        /// Direct, in-band file transfer is not recommended for larger data files.  Many AMQP message broker platforms
        /// limit the maximum total message size of an AMQP message.  Microsoft's Azure message bus, for example, limits messages
        /// to 256KB for a standard subscription, and 1MB for a premium subscription.  RabbitMQ recommends limiting messages to 128MB or less.
        /// Use OutOfBand transfer for larger file sizes.
        /// </summary>
        public FileTransferMode TransferMode
        {
            get;
            set;
        }

        /// <summary>
        /// For file transfers initiated at the destination (FileTransferDirection.Pull), contains information about the file to be transferred.
        /// For file transfers initiated by the source (FileTransferDirection.Push), this property should be NULL.
        /// For FileTransferMode.InBand, this structure will contain the file payload (data) itself.
        /// For FileTransferMode.OutOfBand, this structure will contain a secure link/URL that can be used by the destination
        /// to obtain the file payload data.
        /// </summary>
        public File File
        {
            get;
            set;
        }
    }
}
