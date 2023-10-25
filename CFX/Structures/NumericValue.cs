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
        /// The expected value for this measurement
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
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// The units of the minimum acceptable value (must be a valid SI unit)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public string MinimumAcceptableValueUnits
        {
            get;
            set;
        }
        /// <summary>
        /// The maximum acceptable value
        /// </summary>
        public double? MaximumAcceptableValue
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// The units of the maximum acceptable value (must be a valid SI unit)
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public string MaximumAcceptableValueUnits
        {
            get;
            set;
        }
    }
}
