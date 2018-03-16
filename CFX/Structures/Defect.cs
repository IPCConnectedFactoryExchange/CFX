using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Defect
    {
        public Defect()
        {
            RelatedMeasurements = new List<Measurement>();
            RelatedSymptoms = new List<Symptom>();
            ComponentOfInterest = new ComponentDesignator();
            RegionOfInterest = new Region();
            DefectImages = new List<Image>();
        }

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string DefectCode
        {
            get;
            set;
        }

        public string DefectCategory
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public ComponentDesignator ComponentOfInterest
        {
            get;
            set;
        }

        public List<Image> DefectImages
        {
            get;
            set;
        }

        public Region RegionOfInterest
        {
            get;
            set;
        }

        /// <summary>
        /// The priority of this defect as compared to other defects discovered for this unit.
        /// A priority of 1 indicates the highest priority.
        /// </summary>
        public int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// A floating point number from 1 to 100 indicating the level of confidence
        /// in the validity of this defect.  Intended to be used by humans that screen
        /// the results of inspections made by automated inspection equipment, 
        /// which may produce false defects from time to time.
        /// </summary>
        public double ConfidenceLevel
        {
            get;
            set;
        }

        public List<Measurement> RelatedMeasurements
        {
            get;
            set;
        }

        public List<Symptom> RelatedSymptoms
        {
            get;
            set;
        }
    }
}
