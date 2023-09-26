using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures.SolderPastePrinting;

namespace CFX.Structures
{

    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.6 **</para>
    /// Describes the results of a series of inspections performed on a panel.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.6")]
    public class InspectedPanel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public InspectedPanel()
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
        /// The overall result of the inspections performed on this panel
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

        /// <summary>
        /// Relative stretch ratio of the inspected panel (e.g., value = 1  no stretch / no shrinkage) 
        /// value between 0 and 1: shrinkage;
        /// value above 1: stretch
        /// value null: not possible to send this information
        /// </summary>
        public double? Stretch
        {
            get;
            set;
        }

        /// <summary>
        /// Recognized Squeegee stroke direction
        /// </summary>
        public SolderPasteSqueegeeDirection? RecognizedStrokeDirection
        {
            get;
            set;
        }

        /// <summary>
        /// This structure represents a Fiducial element. It is used to enrich the panel
        /// </summary>
        public List<FiducialInfo> Fiducials
        {
            get;
            set;
        }
        /// <summary>
        /// <para>** NOTE: ADDED in CFX 2.0 **</para>
        /// Optional: Name of the PCB vendor.
        /// </summary>
        [CFX.Utilities.CreatedVersion("2.0")]
        public string PCBVendor
        { 
            get; 
            set;
        }
    }
}

