using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    public class Symptom
    {
        public Symptom()
        {
            ComponentsOfInterest = new List<ComponentDesignator>();
        }

        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string SymptomCode
        {
            get;
            set;
        }

        public string SymptomCategory
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

        public List<Image> SymptomImages
        {
            get;
            set;
        }

        public List<ComponentDesignator> ComponentsOfInterest
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
        /// The priority of this symptom as compared to other symptom discovered for this unit.
        /// A priority of 1 indicates the highest priority.
        /// </summary>
        public int Priority
        {
            get;
            set;
        }

        public List<Measurement> RelatedMeasurements
        {
            get;
            set;
        }
    }
}
