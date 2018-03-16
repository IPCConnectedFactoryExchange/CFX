using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    public class UnitsInspected : CFXMessage
    {
        public UnitsInspected()
        {
            InspectedUnits = new List<InspectedUnit>();
            Inspector = new Operator();
            InspectionMethod = TestMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        public Guid TransactionId
        {
            get;
            set;
        }

        public TestMethod InspectionMethod
        {
            get;
            set;
        }

        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        public Operator Inspector
        {
            get;
            set;
        }

        public List<InspectedUnit> InspectedUnits
        {
            get;
            set;
        }
    }
}
