using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.4 **</para>
    /// Describes a single repair that was performed on a production unit in the course of rework and/or repair.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.4")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Repair
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Repair()
        {
            UniqueIdentifier = Guid.NewGuid().ToString();
            RelatedDefectIdentifiers = new List<string>();
            ReclassifiedDefects = new List<Defect>();
            RelatedSymptomIdentifiers = new List<string>();
            ReclassifiedSymptoms = new List<Symptom>();
        }

        /// <summary>
        /// A unique indentifier describing a particular repair.
        /// Each new occurrence or recurrence of this same repair a new unique identifier.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the nature of the repair performed.
        /// </summary>
        public string RepairName
        {
            get;
            set;
        }


        /// <summary>
        /// Indicates the time when this particular repair began (if known)
        /// </summary>
        public DateTime? RepairStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time when this particular repair ended (if known)
        /// </summary>
        public DateTime? RepairEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Optional comments from the person who performed this repair
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// An optional component or specific component pins related to this repair.
        /// </summary>
        public ComponentDesignator ComponentOfInterest
        {
            get;
            set;
        }


        /// <summary>
        /// An optional location or area on the production unit where the repair is located 
        /// (for cases where there is no specific component related, such as a scratch or 
        /// cosmetic defect).
        /// </summary>
        public Region RegionOfInterest
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the unique identifiers of the previously reported defects to which
        /// this repair relates.  It is assumed that if the repair is successful, these defects
        /// may be considered repaired.
        /// </summary>
        public List<string> RelatedDefectIdentifiers
        {
            get;
            set;
        }

        /// <summary>
        /// If previously reported defects are re-classified during the repair process, the updated details of those
        /// defects may be reported using this property.
        /// </summary>
        public List<Defect> ReclassifiedDefects
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the unique identifiers of the previously reported symptoms (faulty test results) to which
        /// this repair relates.  It is assumed that if the repair is successful, these symptoms
        /// may be considered resolved.
        /// </summary>
        public List<string> RelatedSymptomIdentifiers
        {
            get;
            set;
        }

        /// <summary>
        /// If previously reported symptoms (faulty test results) are re-classified during the repair process, the updated details of those
        /// symptoms may be reported using this property.
        /// </summary>
        public List<Symptom> ReclassifiedSymptoms
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the repair
        /// </summary>
        public RepairResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// In the case that the repair cannot be completed, the error that was the cause of this outcome.
        /// </summary>
        public string Error
        {
            get;
            set;
        }
    }
}
