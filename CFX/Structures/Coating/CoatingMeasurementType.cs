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
        /// <summary>
        /// The Heating value of the coating or encapsulation nozzle, expressed in grad
        /// </summary>
        Heater,
        /// <summary>
        /// The Heating value of the coating or encapsulation nozzle measured through sensor, expressed in grad
        /// </summary>
        Moniter,
        /// <summary>
        /// The distance travelled in X-Axis direction by the coating or encapsulation nozzle, expressed in millimeter(mm)
        /// </summary>
        Axis_X,
        /// <summary>
        /// The distance travelled in Y-Axis direction by the coating or encapsulation nozzle, expressed in millimeter(mm)
        /// </summary>
        Axis_Y,
        /// <summary>
        /// The distance travelled in z-Axis direction by the coating or encapsulation nozzle, expressed in millimeter(mm)
        /// </summary>
        Axis_Z,
        /// <summary>
        /// The pressure of the coating or encapsulation nozzle in case of second pressure pump is used, expressed in kilo Pascals (kPa)
        /// </summary>
        FluidPressure2,
        // <summary>
        /// The total volume of fluid tested after N. no. of units processed, expressed in grams (g)
        /// </summary>
        Fluidweight,
        // <summary>
        /// The level of fluid tested from the container, expressed in millimeter(mm)
        /// </summary>
        material_1_level,
        // <summary>
        /// The level of fluid tested from the container in case of second Container is used, expressed in millimeter(mm)
        /// </summary>
        material_2_level

    }
}
