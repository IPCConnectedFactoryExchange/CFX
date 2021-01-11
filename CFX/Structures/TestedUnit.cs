using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// A data structure that represents a unit under test
    /// </summary>
    public class TestedUnit
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TestedUnit()
        {
            Tests = new List<Test>();
            OverallResult = TestResult.Passed;
        }


        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6). 
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An enumeration indicating the overall result of the testing that was done to this unit
        /// </summary>
        public TestResult OverallResult
        {
            get;
            set;
        }

        /// <summary>
        /// A list of tests that were performed on this unit
        /// </summary>
        public List<Test> Tests
        {
            get;
            set;
        }
    }
}
