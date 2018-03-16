using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class TestedUnit
    {
        public TestedUnit()
        {
            Tests = new List<Test>();
            OverallResult = TestResult.Passed;
        }

        public string UnitIdentifier
        {
            get;
            set;
        }

        public int? UnitPositionNumber
        {
            get;
            set;
        }

        public TestResult OverallResult
        {
            get;
            set;
        }

        public List<Test> Tests
        {
            get;
            set;
        }
    }
}
