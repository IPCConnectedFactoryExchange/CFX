using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

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
    ///   "TransactionId": "2d1bacac-c923-4c38-815c-208685bbe319",
    ///   "TestMethod": "Automated",
    ///   "Tester": {
    ///     "OperatorIdentifier": "UID235434324",
    ///     "ActorType": "Human",
    ///     "FullName": "Joseph Smith",
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
    ///           "UniqueIdentifier": "0e17d9c7-9137-47fb-bddb-816aee913285",
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
    ///               "UniqueIdentifier": "a41473f0-81f5-4b2e-8e67-e8c2daf0afd6",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R21",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": [
    ///                 {
    ///                   "ReferenceDesignator": "R21",
    ///                   "UnitPosition": null,
    ///                   "PartNumber": "41234-8897"
    ///                 }
    ///               ]
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "UniqueIdentifier": "5e7654ce-d62e-43a6-b90d-879af1ad98ca",
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
    ///               "UniqueIdentifier": "98d7a62e-b411-4e68-b788-40ec6cf4b970",
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
    ///                   "UniqueIdentifier": "9f3021f9-dd6e-4cae-955e-014a46d9e665",
    ///                   "MeasurementName": "RESISTANCE_MEASUREMENT_R22",
    ///                   "TimeRecorded": null,
    ///                   "Sequence": 0,
    ///                   "Result": "Passed",
    ///                   "Components": [
    ///                     {
    ///                       "ReferenceDesignator": "R22",
    ///                       "UnitPosition": null,
    ///                       "PartNumber": "41234-8897"
    ///                     }
    ///                   ]
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
    ///           "UniqueIdentifier": "68a2dd81-171c-4184-8de0-ec7aeaf76b49",
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
    ///               "UniqueIdentifier": "ad809cbc-75cb-4ff0-8bbf-98ea000d104d",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R21",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": [
    ///                 {
    ///                   "ReferenceDesignator": "R21",
    ///                   "UnitPosition": null,
    ///                   "PartNumber": "41234-8897"
    ///                 }
    ///               ]
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "UniqueIdentifier": "dd6478ae-0b30-4a7f-a3f7-2ec0ff2e4b9b",
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
    ///               "UniqueIdentifier": "36117d8e-718f-4750-b97f-e4d1e488ceb3",
    ///               "MeasurementName": "RESISTANCE_MEASUREMENT_R22",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": [
    ///                 {
    ///                   "ReferenceDesignator": "R22",
    ///                   "UnitPosition": null,
    ///                   "PartNumber": "41234-8897"
    ///                 }
    ///               ]
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
    ///   "TransactionId": "5dbbe5f6-2b53-4584-a893-229195954789",
    ///   "TestMethod": "Automated",
    ///   "Tester": {
    ///     "OperatorIdentifier": "UID235434324",
    ///     "ActorType": "Human",
    ///     "FullName": "Joseph Smith",
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
    ///           "UniqueIdentifier": "5a94739f-2ad1-423e-b5b2-25601a7e54c0",
    ///           "TestName": "HOT_TEST",
    ///           "TestStartTime": "2018-03-29T13:52:29.6931932-04:00",
    ///           "TestEndTime": "2018-03-29T13:53:01.6931932-04:00",
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
    ///           "UniqueIdentifier": "52bb3411-62f1-434a-a3f1-5e44d1484b9e",
    ///           "TestName": "COLD_TEST",
    ///           "TestStartTime": "2018-03-29T13:52:29.6941918-04:00",
    ///           "TestEndTime": "2018-03-29T13:53:01.6941918-04:00",
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
        /// Identifies the person who performed the test, or operator of the automated equipment that performed the test.
        /// </summary>
        public Operator Tester
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
        public List<TestedUnit> TestedUnits
        {
            get;
            set;
        }
    }
}
