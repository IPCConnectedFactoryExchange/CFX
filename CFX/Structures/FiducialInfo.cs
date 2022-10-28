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
    /// This structure represents a Fiducial element. It is used to enrich the Unit information (e.g., CFX.Structures.UnitInfo) 
    /// <code language="none">
    /// {
    ///     "FiducialX": "10.2",
    ///     "FiducialY": 1.3,
    ///     "FiducialRXY": "0.5",
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    public class FiducialInfo
    {
        /// <summary>
        /// X coordinate of Fiducial on Production Unit
        /// </summary>
        [JsonProperty]
        public double FiducialX
        {
            get;
            set;
        }

        /// <summary>
        /// Y coordinate of Fiducial on Production Unit
        /// </summary>
        [JsonProperty]
        public double FiducialY
        {
            get;
            set;
        }

        /// <summary>
        /// Rotational offset of Fiducial on Production Unit
        /// </summary>
        [JsonProperty]
        public double FiducialRXY
        {
            get;
            set;
        }

        /// <summary>
        /// <para>** NOTE: ADDED in CFX 1.6 **</para>
        /// An unique identifier for the fiducial (optional)
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.6")]
        [JsonProperty]
        public string UniqueIdentifier
        {
            get;
            set;
        }
    }
}
