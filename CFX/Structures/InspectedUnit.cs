using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes the results of a series of inspections performed on a single production unit.
    /// </summary>
    public class InspectedUnit
    {
        public InspectedUnit()
        {
            Inspections = new List<Inspection>();
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
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard)
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the inspections performed on this unit
        /// </summary>
        public TestResult OverallResult
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the verification of the defect
        /// </summary>
        public VerificationResult Verification
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the inspections performed, along with the results
        /// </summary>
        public List<Inspection> Inspections
        {
            get;
            set;
        }
    }
}
