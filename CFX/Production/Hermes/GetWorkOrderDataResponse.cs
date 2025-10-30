using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.Hermes
{
    /// <summary>
    /// Reponse to a request by a Hermes enabled endpoint to acquire information related to a particular work order.
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": "Response success"
    ///   },
    ///   "WorkOrderIdentifier": {
    ///     "WorkOrderId": "WO0001",
    ///     "Batch": "Batch1"
    ///   },
    ///   "ProductTypeId": "Control Card X4",
    ///   "Length": 160.0,
    ///   "Width": 100.0,
    ///   "Thickness": 3.0,
    ///   "TopClearanceHeight": 12.0,
    ///   "BottomClearanceHeight": 5.0,
    ///   "Weight": 200.0,
    ///   "Surface": "PrimarySurface",
    ///   "Route": 1,
    ///   "HermesUnits": [
    ///     {
    ///       "SlotId": 0,
    ///       "BoardId": "5140468a-1a25-47f2-9053-08ac585ce8aa",
    ///       "BoardIdCreatedBy": "Printer12345",
    ///       "FailedBoard": 0,
    ///       "ProductTypeId": null,
    ///       "FlippedBoard": 0,
    ///       "TopBarcode": "BT_M20206500001",
    ///       "BottomBarcode": "B_M20206500001",
    ///       "Lenght": null,
    ///       "Width": null,
    ///       "Thickness": null,
    ///       "ConveyorSpeed": null,
    ///       "TopClearanceHeight": null,
    ///       "BottomClearanceHeight": null,
    ///       "Weight": null,
    ///       "WorkOrderIdentifier": null
    ///     }
    /// }
    /// </code>
    /// </summary>
    public class GetWorkOrderDataResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetWorkOrderDataResponse()
        {
            WorkOrderIdentifier = new WorkOrderIdentifier();
            Surface = Surface.Unspecified;
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
        /// The identifier of the work order whose data was retrieved.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes ProductTypeId of the assembly that is associated with this work order.
        /// </summary>
        public string ProductTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// The length of the PCB in millimeters (mm)
        /// </summary>
        public double Length
        {
            get;
            set;
        }

        /// <summary>
        /// The width of the PCB in millimeters (mm)
        /// </summary>
        public double Width
        {
            get;
            set;
        }

        /// <summary>
        /// The thickness of the PCB in millimeters (mm)
        /// </summary>
        public double Thickness
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the top side of the PCB millimeters (mm)
        /// </summary>
        public double TopClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the bottom side of the PCB millimeters (mm)
        /// </summary>
        public double BottomClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The weight of the PCB in grams (g)
        /// </summary>
        public double Weight
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.3 **</para>
        /// Identifies the surface of the product that is relevant to this Work Order (if any)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.3")]
        public Surface Surface
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.4 **</para>
        /// A number that indicates a routing instruction that will be passed on by Hermes to downstream machines.
        /// Each machine needs to be configured to know how to handle a certain Route number
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.4")]
        public uint Route
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.1 **</para>
        /// List of Hermes units (i.e. Boards) contained in the magazine.
        ///Note: For compatibility reasons with previous CFX versions the existing properties 
        ///in the GetWorkOrderDataResponse shall be filled in as well.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.1")]
        public List<HermesUnit> HermesUnits
        {
            get;
            set;
        }
    }
}
