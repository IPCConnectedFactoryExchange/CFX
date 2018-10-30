using System;
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
        /// List of structures that identify each specific instance of production unit to be disqualified (could be within a carrier or panel). 
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
