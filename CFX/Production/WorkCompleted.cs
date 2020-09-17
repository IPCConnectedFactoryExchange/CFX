using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CFX;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when all work has been completed at a process endpoint.
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "Result": "Completed"
    /// }
    /// </code>
    /// </summary>
    public class WorkCompleted : CFXMessage 
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkCompleted()
        {
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// Related Transaction ID specified previously by WorkStarted Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the overall result of the work transaction.
        /// </summary>
        public WorkResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// OPTIONAL.  Only required if the actual identifiers were not available at the time that the trasnaction was started (at the time 
        /// the WorkStarted message was transmitted).
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
        /// OPTIONAL.  Only required if the actual identifiers were not available at the time that the trasnaction was started (at the time 
        /// the WorkStarted message was transmitted).
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
        /// OPTIONAL.  Only required if the actual identifiers were not available at the time that the trasnaction was started (at the time 
        /// the WorkStarted message was transmitted).
        /// The number of individual production units associated with this transaction.  May be more than 1 in the case of a carrier or panel of multiple PCB’s.
        /// </summary>
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
        /// OPTIONAL.  Only required if the actual identifiers were not available at the time that the trasnaction was started (at the time 
        /// the WorkStarted message was transmitted).
        /// Data that identifies each specific instance of production unit with a carrier or panel. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }

        /// <summary>
        /// OPTIONAL. The Work Order (and Batch, if applicable) to which this work is associated.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }
    }
}
