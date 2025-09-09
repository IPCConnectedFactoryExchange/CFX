using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes details on a vision test of a component
    /// </summary>
    public class ComponentVisionTest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentVisionTest()
        {
        }

        /// <summary>
        /// If of the measured information
        /// </summary>
        public string InformationId
        {
            get;
            set;
        }

        /// <summary>
        /// Vision expected value
        /// </summary>
        public double ExpectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Vision measured value
        /// </summary>
        public double MeasuredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Minimum vision measure tolerance
        /// </summary>
        public double ToleranceMin
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum vision measure tolerance
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
        /// Result of the vision test (true if OK)
        /// </summary>
        public Boolean Result
        {
            get;
            set;
        }
    }
}
