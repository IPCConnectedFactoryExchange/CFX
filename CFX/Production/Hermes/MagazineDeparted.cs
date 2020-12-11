using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Event triggered by a Hermes enabled endpoint when a magazine departed.
    /// <code language="none">
    /// {
    ///   "MagazineData": {
    ///     "MagazineId": "ID12345",
    ///     "HermesUnits": [
    ///       {
    ///         "SlotId": 1,
    ///         "BoardId": "cb8de687-00a1-48a8-a869-314e64cf0e86",
    ///         "BoardIdCreatedBy": "Printer12345",
    ///         "FailedBoard": 1,
    ///         "ProductTypeId": "Product_A",
    ///         "FlippedBoard": 1,
    ///         "TopBarcode": "BT_M20206500001",
    ///         "BottomBarcode": "B_M20206500001",
    ///         "Lenght": 160.0,
    ///         "Width": 100.0,
    ///         "Thickness": 10.0,
    ///         "ConveyorSpeed": 1200.0,
    ///         "TopClearanceHeight": 2.5,
    ///         "BottomClearanceHeight": 1.2,
    ///         "Weight": 80.0,
    ///         "WorkOrderIdentifier": {
    ///           "WorkOrderId": "WO9988776666",
    ///           "Batch": "Batch1"
    ///         }
    ///       },
    ///       {
    ///         "SlotId": 2,
    ///         "BoardId": "4aafb669-eec8-4b7d-b436-641f59bf0529",
    ///         "BoardIdCreatedBy": "Printer12345",
    ///         "FailedBoard": 1,
    ///         "ProductTypeId": "Product_A",
    ///         "FlippedBoard": 1,
    ///         "TopBarcode": "BT_M20206500002",
    ///         "BottomBarcode": "B_M20206500002",
    ///         "Lenght": 160.0,
    ///         "Width": 100.0,
    ///         "Thickness": 10.0,
    ///         "ConveyorSpeed": 1200.0,
    ///         "TopClearanceHeight": 2.5,
    ///         "BottomClearanceHeight": 1.2,
    ///         "Weight": 80.0,
    ///         "WorkOrderIdentifier": {
    ///           "WorkOrderId": "WO9988776666",
    ///           "Batch": "Batch1"
    ///         }
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class MagazineDeparted : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MagazineDeparted()
        {
        
        }

        /// <summary>
        /// Barcode of a magazine, required to identify the magazine.
        /// </summary>
        public Magazine MagazineData
        {
            get;
            set;
        }
    }
}
