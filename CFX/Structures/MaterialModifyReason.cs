using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Reason why the attributes of a material package were modified
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaterialModifyReason
    {
        /// <summary>
        /// No reason specified
        /// </summary>
        Unspecified,
        /// <summary>
        /// Correction of incorrect information
        /// </summary>
        InformationWasIncorrect,
        /// <summary>
        /// Quantity updated after manual count / measurement
        /// </summary>
        ManualCountAndQuantityUpdate,
        /// <summary>
        /// The sensor triggered correction, which is typically the quantity correction when a splice is been detected.
        /// </summary>
        SensorTriggeredCorrection,
    }
}
