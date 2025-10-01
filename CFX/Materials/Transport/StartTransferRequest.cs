using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// This message informs a machine that an AMR has arrived at its location and materials can be transferred from/to the AMR to/from the machine
    /// <code language="none">
    /// {
    ///   "TransportOrderId": "T789012",
    ///   "RelatedWorkOrderId": "WO000567",
    ///   "Materials": {
    ///     "TransportedTools": [
    ///       {
    ///         "UniqueIdentifier": "ID000234",
    ///         "Name": "Tool 1"
    ///       },
    ///       {
    ///         "UniqueIdentifier": "ID000567",
    ///         "Name": "Tool 2"
    ///       }
    ///     ],
    ///     "TransportedMaterialPackages": [
    ///       {
    ///         "UniqueIdentifier": "ID0AB123C",
    ///         "InternalPartNumber": "PN12345",
    ///         "InternalPackageName": "Package components type 1",
    ///         "Quantity": 100000.0,
    ///         "LeadingMaterialPackage": null,
    ///         "BatchId": "B123",
    ///         "BatchMaterialPackage": null,
    ///         "GreyZone": 0.0
    ///       },
    ///       {
    ///         "UniqueIdentifier": "ID0ZW234X",
    ///         "InternalPartNumber": "PN67890",
    ///         "InternalPackageName": "Package components type 2",
    ///         "Quantity": 120000.0,
    ///         "LeadingMaterialPackage": null,
    ///         "BatchId": "B567",
    ///         "BatchMaterialPackage": null,
    ///         "GreyZone": 0.0
    ///       }
    ///     ]
    ///   },
    ///   "StartedBy": "Jon Doe"
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class StartTransferRequest : CFXMessage
    {
        /// <summary>
        /// The order ID of the new transport order
        /// </summary>
        public string TransportOrderId
        {
            get;
            set;
        }
        /// <summary>
        /// The related production work order ID (where applicable)
        /// </summary>
        public string RelatedWorkOrderId
        {
            get;
            set;
        }
        /// <summary>
        /// A list of the specific materials, WIP, and / or production units that are to be transported for this transport order
        /// </summary>
        public TransportedMaterial Materials
        {
            get;
            set;
        }
        /// <summary>
        /// The application or operator who initiated the new transport order
        /// </summary>
        public string StartedBy
        {
            get;
            set;
        }
    }
}
