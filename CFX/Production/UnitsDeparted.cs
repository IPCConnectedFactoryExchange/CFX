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
