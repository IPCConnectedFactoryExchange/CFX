﻿using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// Sent by a process endpoint to identify that a specific production unit is disqualified or scrapped.
    /// This includes logical disqualification in the case that a unit is abandoned during manufacturing
    /// <code language="none">
    /// {
    ///   "Reason": "DefectiveRepairNotPossible",
    ///   "Comments": "The units were accidentally dropped, and irrepairably damaged",
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
    public class UnitsDisqualified : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UnitsDisqualified()
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
        /// The reason why these units are being disqualified (scrapped).
        /// </summary>
        public DisqualificationReason Reason
        {
            get;
            set;
        }

        /// <summary>
        /// Additional free-form comments related to this disqualification.
        /// </summary>
        public string Comments
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
        /// List of structures that identify each specific instance of production unit to be disqualified (could be within a carrier or panel). 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
