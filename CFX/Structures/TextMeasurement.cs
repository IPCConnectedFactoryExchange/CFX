using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a measurement that was made by a human or by automated equipment
    /// in the course of inspecting or testing a production unit in which the result
    /// of the measurement is a text based value.
    /// </summary>
    public class TextMeasurement : Measurement
    {
        /// <summary>
        /// The actual resulting value of this text based measurement
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// The expected value of this text based measurement
        /// </summary>
        public string ExpectedValue
        {
            get;
            set;
        }
    }
}
