using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// Sent by a process endpoint when one or more units have been inspected.  Includes pass/fail information,
    /// as well as a detailed report of the inspection, including the specific measurements and inspections
    /// that were made, and defects that were discovered during the process.
    /// </summary>
    public class UnitsInspected : CFXMessage
    {
        public UnitsInspected()
        {
            InspectedUnits = new List<InspectedUnit>();
            Inspector = new Operator();
            InspectionMethod = TestMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Describes how the inspections were performed
        /// </summary>
        public TestMethod InspectionMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Describes the sampling method that was used during the inspections (if any)
        /// </summary>
        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the inspections, or operator of the automated equipment that performed the inspections
        /// </summary>
        public Operator Inspector
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were inspected, along with the inspections made, 
        /// and inspection results.
        /// </summary>
        public List<InspectedUnit> InspectedUnits
        {
            get;
            set;
        }
    }
}
