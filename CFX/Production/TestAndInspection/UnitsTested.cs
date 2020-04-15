using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// Sent by a process endpoint when one or more units undergo a series of tests.  
    /// Tests can be of any form, including environmental testing, electrical testing, functional testing, etc.  
    /// Detail of each test performed is provided, including any measured values, and the results of each test (P/F).  
    /// For any failed tests, symptom detail is provided.
    /// <para>  </para>
    /// <para>Example 1 (In-Circuit Test of 2 Circuit PCB Panel):</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "c16bb3f4-8088-4697-b789-80faec48ac5a",
    ///   "TestMethod": "Automated",
    ///   "Tester": {
    ///     "OperatorIdentifier": "BADGE489499",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Joseph",
    ///     "LoginName": "joseph.smith@abcdrepairs.com"
    ///   },
    ///   "SamplingInformation": {
    ///     "SamplingMethod": "NoSampling",
    ///     "LotSize": null,
    ///     "SampleSize": null
    ///   },
    ///   "TestedUnits": [
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "Passed",
    ///       "Tests": [
    ///         {
    ///           "UniqueIdentifier": "01aed4e8-fd87-46a4-a62e-57b51f2ee20f",
    ///           "TestName": "RESISTANCE_CHECK_R21",
    ///           "TestStartTime": null,
    ///           "TestEndTime": null,
    ///           "TestConditions": [],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "SymptomsFound": [],
    ///           "DefectsFound": [],
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.NumericMeasurement, CFX",
    ///               "MeasuredValue": {
    ///                 "Value": 28300.0,
    ///                 "ValueUnits": "Ohm",
    ///                 "ExpectedValue": 28.2,
    ///                 "ExpectedValueUnits": "kOhm",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 28.4
    ///               },
    ///               "UniqueIdentifier": "e7398b02-e649-4918-96b8-c426629b6762",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R21",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R21"
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "UniqueIdentifier": "f0f075ab-baef-4a4d-9264-2d2f2948e0fe",
    ///           "TestName": "RESISTANCE_CHECK_R22",
    ///           "TestStartTime": null,
    ///           "TestEndTime": null,
    ///           "TestConditions": [],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Failed",
    ///           "Error": null,
    ///           "SymptomsFound": [
    ///             {
    ///               "UniqueIdentifier": "4db5cb60-140c-41ba-9a27-116dfe3a12cd",
    ///               "SymptomCode": "RESFAIL2",
    ///               "SymptomCategory": "Electrical Tests",
    ///               "Description": "Resistance Value Out of Tolerance",
    ///               "Comments": null,
    ///               "ComponentsOfInterest": [
    ///                 {
    ///                   "ReferenceDesignator": "R22.1",
    ///                   "UnitPosition": null,
    ///                   "PartNumber": "41234-8897"
    ///                 },
    ///                 {
    ///                   "ReferenceDesignator": "R22.2",
    ///                   "UnitPosition": null,
    ///                   "PartNumber": "41234-8897"
    ///                 }
    ///               ],
    ///               "RegionOfInterest": null,
    ///               "Priority": 1,
    ///               "RelatedMeasurements": [
    ///                 {
    ///                   "$type": "CFX.Structures.NumericMeasurement, CFX",
    ///                   "MeasuredValue": {
    ///                     "Value": 28.52,
    ///                     "ValueUnits": "kOhm",
    ///                     "ExpectedValue": 28.2,
    ///                     "ExpectedValueUnits": "kOhm",
    ///                     "MinimumAcceptableValue": 28.0,
    ///                     "MaximumAcceptableValue": 28.4
    ///                   },
    ///                   "UniqueIdentifier": "3092cb6b-2e90-4ede-b9de-c421e16ae18b",
    ///                   "MeasurementName": "RESISTANCE_MEASUREMENT_R22",
    ///                   "TimeRecorded": null,
    ///                   "Sequence": 0,
    ///                   "Result": "Passed",
    ///                   "CRDs": "R22"
    ///                 }
    ///               ]
    ///             }
    ///           ],
    ///           "DefectsFound": [],
    ///           "Measurements": []
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 2,
    ///       "OverallResult": "Passed",
    ///       "Tests": [
    ///         {
    ///           "UniqueIdentifier": "f9127a3a-f349-40f1-9475-e87b83d46ed5",
    ///           "TestName": "RESISTANCE_CHECK_R21",
    ///           "TestStartTime": null,
    ///           "TestEndTime": null,
    ///           "TestConditions": [],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "SymptomsFound": [],
    ///           "DefectsFound": [],
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.NumericMeasurement, CFX",
    ///               "MeasuredValue": {
    ///                 "Value": 28300.0,
    ///                 "ValueUnits": "Ohm",
    ///                 "ExpectedValue": 28.2,
    ///                 "ExpectedValueUnits": "kOhm",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 28.4
    ///               },
    ///               "UniqueIdentifier": "12d217c0-1a15-48dd-9b05-ed5cfaaa87f0",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R21",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R21"
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "UniqueIdentifier": "8eebcda8-dbfa-40b3-b963-36c8c6f979b3",
    ///           "TestName": "RESISTANCE_CHECK_R22",
    ///           "TestStartTime": null,
    ///           "TestEndTime": null,
    ///           "TestConditions": [],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "SymptomsFound": [],
    ///           "DefectsFound": [],
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.NumericMeasurement, CFX",
    ///               "MeasuredValue": {
    ///                 "Value": 28300.0,
    ///                 "ValueUnits": "Ohm",
    ///                 "ExpectedValue": 28.2,
    ///                 "ExpectedValueUnits": "kOhm",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 28.4
    ///               },
    ///               "UniqueIdentifier": "787600e1-fd83-49c5-a2d5-8e3e6e4b3b28",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R22",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R22"
    ///             }
    ///           ]
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>Example 2 (Burn-in / Hot / Cold Test of Final Production Unit):</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "1b3524e0-fd4f-4bd8-93a7-992d12bdb418",
    ///   "TestMethod": "Automated",
    ///   "Tester": {
    ///     "OperatorIdentifier": "BADGE489499",
    ///     "ActorType": "Human",
    ///     "LastName": "Smith",
    ///     "FirstName": "Joseph",
    ///     "LoginName": "joseph.smith@abcdrepairs.com"
    ///   },
    ///   "SamplingInformation": {
    ///     "SamplingMethod": "NoSampling",
    ///     "LotSize": null,
    ///     "SampleSize": null
    ///   },
    ///   "TestedUnits": [
    ///     {
    ///       "UnitIdentifier": "UNIT123456789",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "Passed",
    ///       "Tests": [
    ///         {
    ///           "UniqueIdentifier": "5de9b7e9-9c7c-4e88-9d40-07c7618248a2",
    ///           "TestName": "HOT_TEST",
    ///           "TestStartTime": "2018-10-03T16:02:33.2831984-04:00",
    ///           "TestEndTime": "2018-10-03T16:03:05.2842009-04:00",
    ///           "TestConditions": [
    ///             {
    ///               "$type": "CFX.Structures.Temperature, CFX",
    ///               "StartTime": null,
    ///               "EndTime": null,
    ///               "MeanValue": 45.2,
    ///               "MedianValue": 0.0,
    ///               "MaxValue": 45.8,
    ///               "MinValue": 44.9
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.Humidity, CFX",
    ///               "StartTime": null,
    ///               "EndTime": null,
    ///               "MeanValue": 85.5,
    ///               "MedianValue": 0.0,
    ///               "MaxValue": 85.7,
    ///               "MinValue": 85.4
    ///             }
    ///           ],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "SymptomsFound": [],
    ///           "DefectsFound": [],
    ///           "Measurements": []
    ///         },
    ///         {
    ///           "UniqueIdentifier": "c2668251-aaba-4ceb-a584-55e8b10f0de1",
    ///           "TestName": "COLD_TEST",
    ///           "TestStartTime": "2018-10-03T16:02:33.2842009-04:00",
    ///           "TestEndTime": "2018-10-03T16:03:05.2842009-04:00",
    ///           "TestConditions": [
    ///             {
    ///               "$type": "CFX.Structures.Temperature, CFX",
    ///               "StartTime": null,
    ///               "EndTime": null,
    ///               "MeanValue": -6.5,
    ///               "MedianValue": 0.0,
    ///               "MaxValue": -6.4,
    ///               "MinValue": -6.7
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.Humidity, CFX",
    ///               "StartTime": null,
    ///               "EndTime": null,
    ///               "MeanValue": 22.5,
    ///               "MedianValue": 0.0,
    ///               "MaxValue": 22.7,
    ///               "MinValue": 22.4
    ///             }
    ///           ],
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "SymptomsFound": [],
    ///           "DefectsFound": [],
    ///           "Measurements": []
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class UnitsTested : CFXMessage
    {
        public UnitsTested()
        {
            TestedUnits = new List<TestedUnit>();
            Tester = new Operator();
            TestMethod = TestMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        /// <summary>
        /// The id of the work transaction with which this testing session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Describes how the tests were performed.  
        /// </summary>
        public TestMethod TestMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the test, or operator of the automated equipment that performed the test. (optional)
        /// </summary>
        public Operator Tester
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the recipe used to perform the inspection(s) for this transaction.
        /// </summary>
        public string RecipeName
        {
            get;
            set;
        }

        /// <summary>
        /// An optional Revision Number of the recipe used to perform the inspection(s) for this transaction.
        /// </summary>
        public string RecipeRevision
        {
            get;
            set;
        }

        /// <summary>
        /// Describes the sampling method that was used during the test (if any).  
        /// </summary>
        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were tested, along with the tests made, and test results.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<TestedUnit> TestedUnits
        {
            get;
            set;
        }
    }
}
