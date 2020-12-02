using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Reponse to a request by a Hermes enabled endpoint to acquire information related to a particular magazine.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "MagazineData": {
    ///     "MagazineId": "ID12345",
    ///     "HermesUnits": [
    ///       {
    ///         "SlotId": 1,
    ///         "BoardId": "3ce1c3f6-695d-4eaa-a0eb-cadb9b1eccba",
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
    ///         "BoardId": "67ec444b-24de-4ed3-b7be-1db4ace6ef5f",
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
    public class GetMagazineDataResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetMagazineDataResponse()
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
        /// Barcode of a magazine, required to identify the magazine.
        /// </summary>
        public Magazine MagazineData
        {
            get;
            set;
        }
    }
}
