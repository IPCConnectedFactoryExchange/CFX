using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SMTPlacement
{
    /// <summary>
    /// Types of SMT Placement Faults
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SMTPlacementFaultType
    {
        /// <summary>
        /// Insufficient vacuum to manipulate part.
        /// </summary>
        VacuumError,
        /// <summary>
        /// Problem with the x motion axis
        /// </summary>
        XAxisError,
        /// <summary>
        /// Problem with the y motion axis
        /// </summary>
        YAxisError,
        /// <summary>
        /// Problem with the z motion axis
        /// </summary>
        ZAxisError,
        /// <summary>
        /// Part not recognized by vision system
        /// </summary>
        RecognitionError,
        /// <summary>
        /// Part not picked up properly
        /// </summary>
        PickupError,
        /// <summary>
        /// Part not place properly
        /// </summary>
        PlacementError,
        /// <summary>
        /// Insufficient or incorrect lighting.  Vision system not able to characterize part
        /// </summary>
        LightingError,
        /// <summary>
        /// Error with placement head
        /// </summary>
        HeadError,
        /// <summary>
        /// Error with placement nozzle
        /// </summary>
        NozzleError,
        /// <summary>
        /// Component dropped in transit
        /// </summary>
        ComponentDropped,
        /// <summary>
        /// Material supply exhausted
        /// </summary>
        PartsExhaust,
        /// <summary>
        /// Error decoding fiducial reference mark
        /// </summary>
        FiducialError,
        /// <summary>
        /// Material supply partially exhausted. Can happen if a head is supposed to pickup in several locations and one of them is exhausted
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        PartsPartiallyExhaust,
        /// <summary>
        /// Material supply will soon be exhausted
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        LowQuantity,
        /// <summary>
        /// Error with placement feeder
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        FeederError,
    }
}
