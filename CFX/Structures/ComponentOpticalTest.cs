using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on an optical test of a component
    /// </summary>
    public class ComponentOpticalTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentOpticalTest()
        {
        }

        /// <summary>
        /// Optical expected value
        /// </summary>
        public double ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Optical measured value
        /// </summary>
        public double MeasuredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum optical measure tolerance
        /// </summary>
        public double ToleranceMin
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum optical measure tolerance
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
        /// Result of the optical test (true if OK)
        /// </summary>
        public Boolean Result
        {
            get;
            set;
        }
    }
}
