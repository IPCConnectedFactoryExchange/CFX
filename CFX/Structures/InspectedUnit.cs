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
        /// <summary>
        /// Default constructor
        /// </summary>
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
        /// A list of the inspections performed, along with the results
        /// </summary>
        public List<Inspection> Inspections
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
        /// The count of all the inspections performed.  
        /// If The Inspections array includes both passed and failed inspections
        /// then this parameter would just be the length of that array.  
        /// However if only failed inspections are included in the Inspections
        /// array then just the number of inspections performed (passing and failing) 
        /// can be communicated here so that receiving system can calculate defect
        /// rates. 
        /// </summary>
        public int? TotalInspectionCount
        {
            get;
            set;
        }

    }
}
