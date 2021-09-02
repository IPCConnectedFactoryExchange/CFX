using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Response from a process endpoint to a request to obtatin Unit information.
    /// The reponse lists the units and the related information (e.g., BadMark, Fiducials)
    /// <code language="none">
    /// {
    ///   "PrimaryIdentifier": "SN123456789",
    ///   "HermesIdentifier": null,
    ///   "UnitCount": 2,
    ///   "Units": [
    ///     {
    ///       "BadMark": 0,
    ///       "FiducialCount": 2,
    ///       "Fiducials": [
    ///         {
    ///           "FiducialX": 0.12,
    ///           "FiducialY": 0.16,
    ///           "FiducialRXY": 0.0
    ///         },
    ///         {
    ///           "FiducialX": 0.12,
    ///           "FiducialY": 2.56,
    ///           "FiducialRXY": 0.0
    ///         }
    ///       ],
    ///       "UnitIdentifier": "SN12345",
    ///       "PositionNumber": 1,
    ///       "PositionName": "Circuit1",
    ///       "X": 0.254,
    ///       "Y": 0.556,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "BadMark": 1,
    ///       "FiducialCount": null,
    ///       "Fiducials": null,
    ///       "UnitIdentifier": "SN091235",
    ///       "PositionNumber": 0,
    ///       "PositionName": null,
    ///       "X": 0.0,
    ///       "Y": 0.0,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class GetUnitInfoResponse : CFXMessage
    {
        /// <summary>
        /// The barcode, RFID, etc. of the PCB if available.
        /// </summary>
        public string PrimaryIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// The Hermes BoardId (GUID) of the PCB if available.
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
                return Units != null ? Units.Count : 0;
            }
            private set
            {
            }
        }
        /// <summary>
        /// An optional list of structures that identify each specific instance of production unit (if known).
        /// </summary>
        public List<UnitInfo> Units
        {
            get;
            set;
        }
    }
}
