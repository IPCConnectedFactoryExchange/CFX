using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// This structure contains detailed information (e.g., BadMarks, Fiducials) about a one of a set of production units that are processed simultaneously under a single transaction by an endpoint.
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
    ///     "FlipY": false,
    ///     "BadMark": 0,
    ///     "FiducialCount": 2,
    ///     "Fiducials": [
    ///     {
    ///       "FiducialX": "10.2",
    ///       "FiducialY": 1.3,
    ///       "FiducialRXY": "0.5"
    ///     },
    ///     {
    ///       "FiducialX": "20.8",
    ///       "FiducialY": 7.3,
    ///       "FiducialRXY": "0.0"
    ///     }
    ///   ],
    ///    "CRDs" : []
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class UnitInfo : UnitPosition
    {
        /// <summary>
        /// Is Unit good or not good for production or unknown:
        /// 0: unknown whether unit is good or not good for production
        /// 1: unit is good for production
        /// 2: unit is not good for production
        /// </summary>
        [JsonProperty]
        public int ? BadMark
        {
            get;
            set;
        }

        /// <summary>
        /// The number of Fiducials
        /// </summary>
        [JsonProperty]
        public int ? FiducialCount
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of structures with Fiducial coordinates and rotational offset
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<FiducialInfo> Fiducials
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.7 **</para>
        /// An optional list of component designators (instances of a part) on a production unit(s) to be associated with this measurement.
        /// May include sub-components in "." notation.  Examples:  R1, R2, R3 or  R2.3 (R2, pin 3)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.7")]
        public List<string> CRDs
        {
            get;
            set;
        }
    }
}
