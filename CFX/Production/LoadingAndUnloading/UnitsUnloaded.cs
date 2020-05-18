using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.Production.LoadingAndUnloading
{
    /// <summary>
    /// Sent when a unit is unloaded into any form of carrier, including fixtures, pallets, trays, tubs, totes, carts, etc.
    /// Associates unit with a carrier.
    /// <code language="none">
    /// {
    ///   "UniqueIdentifier": "PALLET123",
    ///   "Units": [
    ///     {
    ///       "UnitIdentifier": "MODULE1",
    ///       "PositionNumber": 1,
    ///       "PositionName": "NEST1",
    ///       "X": 50.45,
    ///       "Y": 80.66,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     },
    ///     {
    ///       "UnitIdentifier": "MODULE2",
    ///       "PositionNumber": 2,
    ///       "PositionName": "NEST2",
    ///       "X": 70.45,
    ///       "Y": 80.66,
    ///       "Rotation": 0.0,
    ///       "FlipX": false,
    ///       "FlipY": false
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class UnitsUnloaded : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public UnitsUnloaded()
        {
            Units = new List<UnitPosition>();
        }

        /// <summary>
        /// The unique identifier for this carrier (barcode, RFID, etc.)
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific units that were unloaded along with positions they were unloaded to.
        /// </summary>
        public List<UnitPosition> Units
        {
            get;
            set;
        }
    }
}
