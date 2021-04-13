using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Structure that contains information related to a Unit (Board) according to the Hermes standard.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class HermesUnit
    {
        /// <summary>
        /// Indicates the slot in the magazine, enumerated from bottom to top, beginning with 1.
        /// </summary>
        public int SlotId
        {
            get;
            set;
        }

        /// <summary>
        /// Indicating the ID of the available board (GUID, 36 bytes)
        /// </summary>
        public string BoardId
        {
            get;
            set;
        }

        /// <summary>
        /// MachineId of the machine which created the BoardId 
        /// (the first machine in a consecutive row of machines implementing this protocol). 
        /// The MachineId is part of the Hermes configuration.
        /// </summary>
        public string BoardIdCreatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// A value of the list below.
        /// 0	Board of unknown quality available
        /// 1	Good board available
        /// 2	Failed board available
        /// </summary>
        public int FailedBoard
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies a collection of printed boards sharing common properties.
        /// </summary>
        public string ProductTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// A value of the list below:
        /// 0	Side up is unknown
        /// 1	Board top side is up
        /// 2	Board bottom side is up
        /// </summary>
        public int FlippedBoard
        {
            get;
            set;
        }

        /// <summary>
        /// The barcode of the top side of the printed board.
        /// </summary>
        public string TopBarcode
        {
            get;
            set;
        }

        /// <summary>
        /// The barcode of the bottom side of the printed board.
        /// </summary>
        public string BottomBarcode
        {
            get;
            set;
        }

        /// <summary>
        /// The length of the printed board in millimeter.
        /// </summary>
        public double? Lenght
        {
            get;
            set;
        }

        /// <summary>
        /// The width of the printed board in millimeter.
        /// </summary>
        public double? Width
        {
            get;
            set;
        }

        /// <summary>
        /// The thickness of the printed board in millimeter.
        /// </summary>
        public double? Thickness
        {
            get;
            set;
        }

        /// <summary>
        /// The conveyor speed preferred by the upstream machine in millimeter per second.
        /// </summary>
        public double? ConveyorSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the top side of the printed board in millimeter.
        /// </summary>
        public double? TopClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The clearance height for the bottom side of the printed board in millimeter.
        /// </summary>
        public double? BottomClearanceHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The weight of the printed board in grams.
        /// </summary>
        public double? Weight
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the Work Order (Batch and ID).
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }
    }
}
