using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Rejection reason
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RejectionReason
    {
        /// <summary>
        /// Rejection reason is unknown 
        /// </summary>
        Unknown,
        /// <summary>
        /// The component was not placed because of a mechanical error
        /// </summary>
        MechanicalError,
        /// <summary>
        /// The component was not placed because of an electrical error
        /// </summary>
        ElectricalError,
        /// <summary>
        /// The component was not placed because of a software error
        /// </summary>
        SoftwareError,
        /// <summary>
        /// The component was not placed because of an error from an external device
        /// </summary>
        ExternalDeviceError,
        /// <summary>
        /// The component was rejected because of a bad electrical test
        /// </summary>
        BadElectricalTest,
        /// <summary>
        /// The component was rejected because of a generic error detected after pickup
        /// </summary>
        ErrorAfterPickUp,
        /// <summary>
        /// The component was rejected because of a bad vision test after pickup
        /// </summary>
        BadVisionTestAfterPickup,
        /// <summary>
        /// The component was rejected because of a bad pressure test after pickup
        /// </summary>
        BadPressureTestAfterPickup,
        /// <summary>
        /// The component was rejected because of a bad optical test after pickup
        /// </summary>
        BadOpticalTestAfterPickup,
        /// <summary>
        /// The component was rejected because of a wrong placement
        /// </summary>
        ErrorAfterPlacement,
        /// <summary>
        /// The component was rejected because of a bad vision test after placement
        /// </summary>
        BadVisionTestAfterPlacement,
        /// <summary>
        /// The component was rejected because of a bad pressure test after placement
        /// </summary>
        BadPressureTestAfterPlacement,
        /// <summary>
        /// The component was rejected because of a bad optical test after placement
        /// </summary>
        BadOpticalTestAfterPlacement,
        /// <summary>
        /// The component was rejected because of a bad vision test before pickup
        /// </summary>
        BadVisionTestBeforePickup,
    }
}
