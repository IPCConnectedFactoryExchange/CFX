using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on an electrical test of a component
    /// </summary>
    public class ComponentElectricalTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentElectricalTest()
        {
        }

        /// <summary>
        /// Serial number of the electrical tester
        /// </summary>
        public string TesterSerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Frequency used for the measure (Hertz)
        /// </summary>
        public double Frequency
        {
            get;
            set;
        }

        /// <summary>
        /// Electrical expected value
        /// </summary>
        public double ExpectedValue
        {
            get;
            set;
        }
		
		/// <summary>
        /// Electrical measured value
        /// </summary>
        public double MeasuredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum electrical measure tolerance
        /// </summary>
        public double ToleranceMin
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum electrical measure tolerance
        /// </summary>
        public double ToleranceMax
        {
            get;
            set;
        }

        /// <summary>
        /// Unit used for the Expected value, the Mesasured value, and the Tolerances
        /// </summary>
        public ComponentElectricalTestUnit Unit
        {
            get;
            set;
        }
        
        /// <summary>
        /// Result of the electrical test (true if OK)
        /// </summary>
        public Boolean Result
        {
            get;
            set;
        }
    }
}
