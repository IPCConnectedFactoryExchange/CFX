using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class InspectedUnit
    {
        public InspectedUnit()
        {
            Inspections = new List<Inspection>();
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

        public List<Inspection> Inspections
        {
            get;
            set;
        }
    }
}
