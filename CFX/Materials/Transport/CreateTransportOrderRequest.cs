using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Message request to create transport order; it shall contain all necessary data for one or more transports 
    /// while leaving sufficient flexibility to make use of different Fleet Manager capabilities.
    /// <code language="none">
    /// {
    ///   "TransportOrderId": "T123456",
    ///   "RelatedWorkOrderId": "WO000123",
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
    ///   "Source": "Location 1",
    ///   "FinalDestination": "Location 2",
    ///   "StartedBy": "MaterialTower1",
    ///   "Priority": 2,
    ///   "TargetDeliveryTime": "2024-11-12T15:13:54.4355998+01:00"
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class CreateTransportOrderRequest : CFXMessage
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
        /// The point of origination for this this transport order
        /// </summary>
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// The final destination for this transport order
        /// </summary>
        public string FinalDestination
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
        /// <summary>
        /// The priority low – medium – high for the new transport order
        /// </summary>
        public TransportPriority Priority 
        {
            get;
            set;
        }
        /// <summary>
        /// The target delivery time for completing the new transport order
        /// </summary>
        public DateTime TargetDeliveryTime
        {
            get;
            set;
        }
    }
}
