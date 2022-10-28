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
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        Heater,
        /// <summary>
        /// The Heating value of the coating or encapsulation nozzle measured through sensor, expressed in grad
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        Monitor,
        /// <summary>
        /// The axis position describing the direction in which the coating or encapsulation nozzle displaced, expressed in millimeter(mm)
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        Axis,
        /// <summary>
        /// The total volume of fluid tested after n number of units processed, expressed in grams (g)
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        Fluidweight,
        /// <summary>
        /// The level of fluid tested from the container or Beaker, expressed in millimeter(mm)
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        MaterialLevel,
        /// <summary>
        /// The Width of adjustable Nozzle Eg. Curtain Nozzle, expressed in millimeter(mm)
        /// <para>** NOTE: ADDED in CFX 1.5 **</para>
        /// </summary>
        [CFX.Utilities.CreatedVersion("1.5")]
        NozzleWidth

    }
}
