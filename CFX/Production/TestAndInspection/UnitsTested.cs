using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    public class UnitsTested : CFXMessage
    {
        public UnitsTested()
        {
            TestedUnits = new List<TestedUnit>();
            Tester = new Operator();
            TestMethod = TestMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        public Guid TransactionId
        {
            get;
            set;
        }

        public Operator Tester
        {
            get;
            set;
        }

        public TestMethod TestMethod
        {
            get;
            set;
        }

        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        public List<TestedUnit> TestedUnits
        {
            get;
            set;
        }
    }
}
