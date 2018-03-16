using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class Test
    {
        public Test()
        {
            SymptomsFound = new List<Symptom>();
            DefectsFound = new List<Defect>();
            Measurements = new List<Measurement>();
            TestConditions = new List<EnvironmentalCondition>();
        }

        /// <summary>
        /// A unique indentifier describing a particular instance of a test that was undertaken.
        /// Each new occurrence or recurrence of this same inspection gets a new unique identifier.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }

        public string TestName
        {
            get;
            set;
        }

        public DateTime? TestStartTime
        {
            get;
            set;
        }

        public DateTime? TestCompletionTime
        {
            get;
            set;
        }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<EnvironmentalCondition> TestConditions
        {
            get;
            set;
        }

        /// <summary>
        /// Procedure to be followed to perform this test (primarily for human driven test).
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
        /// In the case that the test cannot be completed, the error that was the cause of this outcome.
        /// </summary>
        public string Error
        {
            get;
            set;
        }

        public List<Symptom> SymptomsFound
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
