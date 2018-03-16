using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Inspection
    {
        public Inspection()
        {
            DefectsFound = new List<Defect>();
            Measurements = new List<Measurement>();
        }

        /// <summary>
        /// A unique indentifier describing a particular instance of an inspection was made.
        /// Each new occurrence or recurrence of this same inspection gets a new unique identifier.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string InspectionName
        {
            get;
            set;
        }

        public DateTime? InspectionTime
        {
            get;
            set;
        }

        /// <summary>
        /// Procedure to be followed to perform this inspection (primarily for human driven inspection).
        /// </summary>
        public string TestProcedure
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }
        
        public TestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// In the case that the inspection cannot be completed, the error that was the cause of this outcome.
        /// </summary>
        public string Error
        {
            get;
            set;
        }

        public List<Defect> DefectsFound
        {
            get;
            set;
        }

        public List<Measurement> Measurements
        {
            get;
            set;
        }
    }
}
