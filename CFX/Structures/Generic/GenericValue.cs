using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures.Generic
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.1 **</para>
    /// A named numeric value used to represent either a setpoint or a reading within a
    /// <see cref="GenericProcessData"/> structure.  When used as a setpoint, only the
    /// <see cref="NumericValue.Value"/> and <see cref="NumericValue.ValueUnits"/> properties
    /// are typically populated.  When used as a reading, the expected value and acceptable
    /// range properties may also be populated.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.1")]
    public class GenericValue
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GenericValue()
        {
            Value = new NumericValue();
        }

        /// <summary>
        /// A name that uniquely identifies this value within the containing process data
        /// (for example, "HeaterTemperature", "ConveyorSpeed", "SpindleRPM").
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The numeric value along with its units and optional expected / minimum / maximum
        /// acceptable values.
        /// </summary>
        public NumericValue Value
        {
            get;
            set;
        }
    }
}
