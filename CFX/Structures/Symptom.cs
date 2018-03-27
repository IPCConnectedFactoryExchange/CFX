using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a situation where a problem is identified via one or more failed tests.
    /// A symptom does not identify the actual cause of the failure(s), only that 
    /// there is a problem that needs to be investigated. 
    /// </summary>
    public class Symptom
    {
        public Symptom()
        {
            ComponentsOfInterest = new List<ComponentDesignator>();
            Priority = 1;
        }

        /// <summary>
        /// A unique identifier for this particular symptom instance
        /// (new and unique each time a new symptom is discovered).
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// A code identifying the type of symptom
        /// </summary>
        public string SymptomCode
        {
            get;
            set;
        }

        /// <summary>
        /// An optional symptom category for this particular type of symptom
        /// </summary>
        public string SymptomCategory
        {
            get;
            set;
        }

        /// <summary>
        /// A human friendly description of the symptom
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Optional comments from the tester who discovered this symptom
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the components or specific component pins related to this symptom (if known)
        /// </summary>
        public List<ComponentDesignator> ComponentsOfInterest
        {
            get;
            set;
        }

        /// <summary>
        /// An optional location or area on the production unit where the symptom is located 
        /// (for cases where there is no specific components that can be definitively related).
        /// </summary>
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

        /// <summary>
        /// A list of measurements that were taken which caused this symptom to be created
        /// </summary>
        public List<Measurement> RelatedMeasurements
        {
            get;
            set;
        }
    }
}
