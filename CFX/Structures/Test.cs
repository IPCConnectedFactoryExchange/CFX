using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// Describes a single test in a series of test that an tester makes (both human or automation)
    /// in the course of testing a production unit.
    /// </summary>
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

        /// <summary>
        /// Identifies the nature of the test performed
        /// </summary>
        public string TestName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time when this particular test began (if known)
        /// </summary>
        public DateTime? TestStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time when this particular test ended (if known)
        /// </summary>
        public DateTime? TestEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// A list of environmental conditions (temperature, humidity, etc.) which
        /// were in place when the test was performed.
        /// </summary>
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

        /// <summary>
        /// Optional comments from the tester who tested the unit
        /// </summary>
        public string Comments
        {
            get;
            set;
        }

        /// <summary>
        /// The overall result of the test
        /// </summary>
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

        /// <summary>
        /// The symptoms that were discovered in the course of this test
        /// </summary>
        public List<Symptom> SymptomsFound
        {
            get;
            set;
        }

        /// <summary>
        /// The defects that were discovered in the course of this test
        /// </summary>
        public List<Defect> DefectsFound
        {
            get;
            set;
        }

        /// <summary>
        /// The measurements that were taken in the course of performing this test.
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
