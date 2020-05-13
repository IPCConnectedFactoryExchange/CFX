using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a pressure test of a component
    /// </summary>
    public class ComponentPressureTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentPressureTest()
        {
        }

        /// <summary>
        /// Pressure expected value
        /// </summary>
        public double ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Pressure measured value
        /// </summary>
        public double MeasuredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum pressure measure tolerance
        /// </summary>
        public double ToleranceMin
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum pressure measure tolerance
        /// </summary>
        public double ToleranceMax
        {
            get;
            set;
        }

        /// <summary>
        /// Unit used for the Expected value, the Mesasured value, and the Tolerances
        /// </summary>
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        /// Result of the pressure test (true if OK)
        /// </summary>
        public Boolean Result
        {
            get;
            set;
        }
    }
}
