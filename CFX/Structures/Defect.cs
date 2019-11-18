using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a defect that was discovered on a production unit
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Defect
    {
        public Defect()
        {
            //RelatedMeasurements = new List<Measurement>();
            //RelatedSymptoms = new List<Symptom>();
            //ComponentOfInterest = new ComponentDesignator();
            //RegionOfInterest = new Region();
            //DefectImages = new List<Image>();
            UniqueIdentifier = Guid.NewGuid().ToString();
            //Priority = 1;
            //ConfidenceLevel = 100.0;
        }

        /// <summary>
        /// A unique identifier for this particular defect instance
        /// (new and unique each time a new defect is discovered).
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// A code identifying the type of defect
        /// </summary>
        public string DefectCode
        {
            get;
            set;
        }

        /// <summary>
        /// An optional defect category for this particular type of defect
        ///   The defect that led to the faulty feature, determined manually during verification.
        ///   Suggested values are:
        ///   - ClearenceSurfaceError
        ///   - ComponentDefective
        ///   - ComponentMissing
        ///   - ComponentRotated
        ///   - ComponentShifted
        ///   - ComponentTilted
        ///   - ConformalCoatingError
        ///   - Contamination
        ///   - ExcessiveSolder
        ///   - FaceDownComponent
        ///   - InsufficientSolder
        ///   - LiftedLead
        ///   - Miscellaneous
        ///   - PasteShort
        ///   - PinMissing
        ///   - PinShifted
        ///   - ReferencePlaneError
        ///   - ShiftedPaste
        ///   - Short
        ///   - Solderball
        ///   - SolderDefect
        ///   - SolderPasteDefect
        ///   - Tombstone
        ///   - WrongCode
        ///   - WrongComponent
        ///   - WrongComponentHeight
        ///   - WrongPasteArea
        ///   - WrongPasteHeight
        ///   - WrongPasteVolume
        ///   - WrongPinHeight
        ///   - WrongPolarity
        /// </summary>
        public string DefectCategory
        {
            get;
            set;
        }

        /// <summary>
        /// A human friendly description of the defect
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Optional comments from the inspector who discovered this defect
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// An optional component or specific component pins related to this defect.
        /// </summary>
        public ComponentDesignator ComponentOfInterest
        {
            get;
            set;
        }


        /// <summary>
        /// An optional location or area on the production unit where the defect is located 
        /// (for cases where there is no specific component related, such as a scratch or 
        /// cosmetic defect).
        /// </summary>
        public Region RegionOfInterest
        {
            get;
            set;
        }

        /// <summary>
        /// One of more pictures/images of the defect
        /// </summary>
        public List<Image> DefectImages
        {
            get;
            set;
        }

        /// <summary>
        /// The priority of this defect as compared to other defects discovered for this unit.
        /// A priority of 1 indicates the highest priority.
        /// </summary>
        public int? Priority
        {
            get;
            set;
        }

        /// <summary>
        /// A floating-point number from 1 to 100 indicating the level of confidence
        /// in the validity of this defect.  Intended to be used by humans that screen
        /// the results of inspections made by automated inspection equipment, 
        /// which may produce false defects from time to time.
        /// </summary>
        public double? ConfidenceLevel
        {
            get;
            set;
        }

        /// <summary>
        /// A list of measurements that were taken in the course of discovering this defect
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Measurement> RelatedMeasurements
        {
            get;
            set;
        }

        /// <summary>
        /// A list of symptoms that were discovered in the course of identifying this defect.
        /// </summary>
        public List<Symptom> RelatedSymptoms
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the verification of the measurement
        /// </summary>
        public VerificationResult Verification
        {
            get;
            set;
        }

        /// <summary>
        /// When a verification took place, the VerificationDetail will contain a classification or more detailed description
        /// of the root cause of the defect or why the defect is a false fail.
        /// This description is typically maintained by the customer and the operator will choose from a predefined list.
        /// </summary>
        public string VerificationDetail 
        {
            get;
            set;
        }
    }
}
