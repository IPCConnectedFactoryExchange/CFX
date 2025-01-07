using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Class representing the Measurement captured during the calibration process.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    public class CalibrationMeasurement
    {
        /// <summary>
        /// A name that uniquely describes the measurement that was performed.
        /// </summary>
        public string MeasurementName
        {
            get;
            set;
        }
        /// <summary>
        /// The measured value including actual value, as well as expected, minimum and maximum value.
        /// </summary>
        public NumericValue MeasurementValue  
        { 
            get; 
            set; 
        }
    }
}
