using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// An enumeration indicating the type of measurement made within a coating or encapsulation machine.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CoatingMeasurementType
    {
        /// <summary>
        /// The pressure of the coating or encapsulation nozzle, expressed in kilo Pascals (kPa)
        /// </summary>
        FluidPressure,
        /// <summary>
        /// The total volume of fluid dispensed, expressed in cubic centimeters (cc)
        /// </summary>
        FluidVolume,
    }
}
