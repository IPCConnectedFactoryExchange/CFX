using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// A data structure that represents a numeric value with defined units and thresholds
    /// </summary>
    public class NumericValue
    {
        /// <summary>
        /// The actual numeric value that was measured and recorded during a test or inspection
        /// </summary>
        public double Value
        {
            get;
            set;
        }

        /// <summary>
        /// The units of the value (must be a valid SI unit)
        /// </summary>
        public string ValueUnits
        {
            get;
            set;
        }

        /// <summary>
        /// The expected value for thie measurement
        /// </summary>
        public double? ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// The units of the expected value (must be a valid SI unit)
        /// </summary>
        public string ExpectedValueUnits
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum acceptable value
        /// </summary>
        public double? MinimumAcceptableValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum acceptable value
        /// </summary>
        public double? MaximumAcceptableValue
        {
            get;
            set;
        }
    }
}
