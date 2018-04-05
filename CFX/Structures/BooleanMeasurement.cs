using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a measurement that was made by a human or by automated equipment
    /// in the course of inspecting or testing a production unit in which the result
    /// of the measurement is a boolean (true / fales) value.
    /// </summary> 
    public class BooleanMeasurement : Measurement
    {
        /// <summary>
        /// The actual resulting value of this measurement
        /// </summary>
        public bool Value
        {
            get;
            set;
        }

        /// <summary>
        /// The expected value of this measurement
        /// </summary>
        public bool ExpectedValue
        {
            get;
            set;
        }
    }
}
