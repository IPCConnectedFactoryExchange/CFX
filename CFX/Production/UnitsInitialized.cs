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
        /// The Work Order (and Batch, if applicable) to which these new production units are associated.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
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
