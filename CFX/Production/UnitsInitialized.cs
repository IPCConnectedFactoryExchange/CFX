using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent when one or more production units are first introduced into the production process flow. 
    /// Unit initialization most often occurs when new production units are first labeled with unique identifiers (or laser marked)
    /// <code language="none">
    /// {
    ///   "WorkOrderIdentifier": {
    ///     "WorkOrderId": "WO45648798",
    ///     "Batch": "BATCH45648798-1"
    ///   },
    ///   "TransactionID": null,
    ///   "UnitCount": 2,
    ///   "Units": [
    ///     {
    ///       "UnitIdentifier": "UNIT5566687",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT1",
    ///       "X": 50.45,
    ///       "Y": 80.66,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "UNIT5566688",
    ///       "PositionNumber": 2,
    ///       "PositionName": "CIRCUIT2",
    ///       "X": 50.45,
    ///       "Y": 80.66,
    ///       "Rotation": 90.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class UnitsInitialized : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitsInitialized()
        {
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// If units are being initialized as part of a Work transaction, the related Transaction ID specified previously by the WorkStarted Message.
        /// Only required if initialization is occurring as part of a Work transaction, such as in the case of a laser marking machine or labeler.
        /// </summary>
        public Guid? TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// The barcode, RFID, etc. that was most recently acquired by the scanner / reader.  If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The Hermes BoardId of the carrier, a PCB panel or single production unit. If a single production unit is moving through the
        /// process, this would be the actual unique identifier of that individual unition unit.  However, if multiple production units are moving
        /// through the process as a group (as in the case of a PCB panel, a fixture, or any sort of carrier), this would be an identifier that
        /// represents the entire group of units, such as a carrier UID, a PCB panel UID, etc.
        /// HermesIdentifier will be transfered between all machines which support Hermes. The PrimaryIdentifier is containing a barcode information.
        /// Both can be transferred.
        /// <remarks>
        /// Espcially when the line does not support the Hermes standard in the hole line, the Hermes Identifier can be unique only in the a part
        /// of the line. The Primary Identifier can be used to correlate the parts of hermes sublines to correlate this data as well. 
        /// </remarks>
        /// </summary>
        public string HermesIdentifier 
        {
            get;
            set;
        }

        /// <summary>
        /// The Work Order (and Batch, if applicable) to which these new production units are associated.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// The number of individual production units
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public int UnitCount
        {
            get
            {
                return Units.Count;

            }
            private set
            {
            }
        }
        /// <summary>
        /// A list of structures that identify each specific instance of production unit that have been initialized.
        /// Could be individual units, or within a carrier, panel, etc. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
