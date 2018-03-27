using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// Sent by a process endpoint when one or more units undergo a series of tests.  
    /// Tests can be of any form, including environmental testing, electrical testing, functional testing, etc.  
    /// Detail of each test performed is provided, including any measured values, and the results of each test (P/F).  
    /// For any failed tests, symptom detail is provided.
    /// </summary>
    public class UnitsTested : CFXMessage
    {
        public UnitsTested()
        {
            TestedUnits = new List<TestedUnit>();
            Tester = new Operator();
            TestMethod = TestMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        /// <summary>
        /// The id of the work transaction with which this testing session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Describes how the tests were performed.  
        /// </summary>
        public TestMethod TestMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the test, or operator of the automated equipment that performed the test.
        /// </summary>
        public Operator Tester
        {
            get;
            set;
        }

        /// <summary>
        /// Describes the sampling method that was used during the test (if any).  
        /// </summary>
        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were tested, along with the tests made, and test results.
        /// </summary>
        public List<TestedUnit> TestedUnits
        {
            get;
            set;
        }
    }
}
