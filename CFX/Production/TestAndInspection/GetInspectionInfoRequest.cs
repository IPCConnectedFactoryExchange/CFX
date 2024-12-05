using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// This message is used to request a process endpoint for the inspections performed on a list of Units
    /// <code language="none">
    /// {
    ///   "PrimaryIdentifier": "6d13e7f2-ccef-4fca-9814-7d5ca2091f93",
    ///   "HermesIdentifier": "",
    ///   "Units": [
    ///     {
    ///       "BadMark": null,
    ///       "FiducialCount": null,
    ///       "Fiducials": null,
    ///       "CRDs": [
    ///         "R1",
    ///         "R2",
    ///         "R3.1"
    ///       ],
    ///       "UnitIdentifier": "SN123456",
    ///       "PositionNumber": 1,
    ///       "PositionName": null,
    ///       "X": 0.0,
    ///       "Y": 0.0,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false,
    ///       "Status": "Fail"
    ///     },
    ///     {
    ///       "BadMark": null,
    ///       "FiducialCount": null,
    ///       "Fiducials": null,
    ///       "CRDs": [
    ///         "R5",
    ///         "R6",
    ///         "R7.1"
    ///       ],
    ///       "UnitIdentifier": "SN9012345",
    ///       "PositionNumber": 2,
    ///       "PositionName": null,
    ///       "X": 0.0,
    ///       "Y": 0.0,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false,
    ///       "Status": "Fail"
    ///     },
    ///     {
    ///       "BadMark": null,
    ///       "FiducialCount": null,
    ///       "Fiducials": null,
    ///       "CRDs": [
    ///         "R9",
    ///         "R10",
    ///         "R11.1"
    ///       ],
    ///       "UnitIdentifier": "SN0012347",
    ///       "PositionNumber": 3,
    ///       "PositionName": null,
    ///       "X": 0.0,
    ///       "Y": 0.0,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false,
    ///       "Status": "Skip"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    public class GetInspectionInfoRequest : CFXMessage
    {
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
        /// The Hermes BoardId (GUID) of the carrier, a PCB panel or single production unit – 
        /// optional, may be used when PrimaryIdentifier is not available.
        /// </summary>
        public string HermesIdentifier
        {
            get;
            set;
        }

        ///<summary>
        /// List of Units for which inspection data is queried
        /// </summary>
        public List<UnitInfo> Units
        {
            get;
            set;
        }
    }
}
