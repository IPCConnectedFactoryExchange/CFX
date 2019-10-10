using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a single step in a series of steps that an inspector makes (both human or automation)
    /// in the course of inspecting a production unit.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
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

        /// <summary>
        /// Identifies the nature of the inspection performed
        /// </summary>
        public string InspectionName
        {
            get;
            set;
        }


        /// <summary>
        /// Indicates the time when this particular inspection began (if known)
        /// </summary>
        public DateTime? InspectionStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time when this particular inspection ended (if known)
        /// </summary>
        public DateTime? InspectionEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Procedure to be followed to perform this inspection (primarily for human driven inspection)
        /// </summary>
        public string TestProcedure
        {
            get;
            set;
        }

        /// <summary>
        /// Optional comments from the inspector who inspected the unit
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the inspection
        /// </summary>
        public TestResult Result
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
        /// In the case that the inspection cannot be completed, the error that was the cause of this outcome.
        /// </summary>
        public string Error
        {
            get;
            set;
        }

        /// <summary>
        /// The defects that were discovered in the course of performing this inspection (if any)
        /// </summary>
        public List<Defect> DefectsFound
        {
            get;
            set;
        }

        /// <summary>
        /// Any symptoms that were discovered during the inspection (if any).
        /// </summary>
        public List<Symptom> Symptoms
        {
            get;
            set;
        }

        /// <summary>
        /// The measurements that were taken in the course of performing this inspection (if any).
        /// NOTE - Only measurements not related to particular defects or symptoms should be recorded here.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Measurement> Measurements
        {
            get;
            set;
        }
    }
}
