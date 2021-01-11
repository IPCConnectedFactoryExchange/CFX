using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a numeric (floating point) measurement that was made by a human or by automated equipment
    /// in the course of inspecting or testing a production unit
    /// </summary>
    public class NumericMeasurement : Measurement
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public NumericMeasurement() : base()
        {
            MeasuredValue = new NumericValue();
        }

        /// <summary>
        /// The actual numeric value measured and recorded during this test/inspection.
        /// </summary>
        public NumericValue MeasuredValue
        {
            get;
            set;
        }
    }
}
