using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint when units physically depart from a process endpoint. 
    /// This does not imply any information about any activity that may have taken place.
    /// <code language="none">
    /// {
    ///   "UnitCount": 2,
    ///   "Units": [
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
    ///       "PositionName": "CIRCUIT1",
    ///       "X": 50.45,
    ///       "Y": 80.66,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "CARRIER5566",
    ///       "PositionNumber": 1,
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
    public class UnitsDeparted : CFXMessage
    {
        public UnitsDeparted()
        {
            Units = new List<UnitPosition>();
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
        /// The number of individual production units
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
        /// An optional list of structures that identify each specific instance of production unit that arrived (if known).
        /// Could be individual units, or within a carrier, panel, etc. 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }

        /// <summary>
        /// Lane identifier.  Null if no specific lane
        /// </summary>
        public int? Lane
        {
            get;
            set;
        }
    }
}
