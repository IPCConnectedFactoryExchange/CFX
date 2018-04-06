using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// This structure contains information about a one of a set of production units that are processed simultaneously under a single transaction by an endpoint.
    /// Units may be identified in one of two ways:
    ///     1.  The UnitIdentifier property represents the actual unique identifier of the production unit.
    ///     2.  The UnitIdentifier property represents the unique identifier of the "carrier" or "PCB panel"
    ///         AND the PositionNumber property represents the position of the unit within the carrier/panel.
    ///         PositionNumber's are established as defined in the CFX Standard.
    /// <code language="none">
    /// {
    ///     "UnitIdentifier": "CARRIER5566",
    ///     "PositionNumber": 1,
    ///     "PositionName": "CIRCUIT1",
    ///     "X": 0.254,
    ///     "Y": 0.556,
    ///     "Rotation": 0.0,
    ///     "FlipX": false,
    ///     "FlipY": false
    /// }
    /// </code>
    /// </summary>
    public class UnitPosition
    {
        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        [JsonProperty]
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6). 
        /// </summary>
        [JsonProperty]
        public int PositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Optional name of position
        /// </summary>
        public string PositionName
        {
            get;
            set;
        }

        /// <summary>
        /// X coordinate of Production unit origin, as it is known to the endpoint
        /// </summary>

        public double X
        {
            get;
            set;
        }

        /// <summary>
        /// Y coordinate of Production unit origin, as it is known to the endpoint
        /// </summary>
        public double Y
        {
            get;
            set;
        }

        /// <summary>
        /// Original rotation of Production unit, as it is known to the endpoint (in degrees)
        /// </summary>
        public double Rotation
        {
            get;
            set;
        }

        /// <summary>
        /// Is production unit flipped in X-direction
        /// </summary>
        public bool FlipX
        {
            get;
            set;
        }

        /// <summary>
        /// Is production unit flipped in Y-direction
        /// </summary>
        public bool FlipY
        {
            get;
            set;
        }
    }
}
