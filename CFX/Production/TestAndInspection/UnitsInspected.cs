using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// Sent by a process endpoint when one or more units have been inspected.  Includes pass/fail information,
    /// as well as a detailed report of the inspection, including the specific measurements and inspections
    /// that were made, and defects that were discovered during the process.
    /// <para>  </para>
    /// <para>Generic Inspection Example (2 Circuit PCB Panel inspected via AOI):</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "31aaff27-ec09-4c75-8de0-2d6cf2855e5f",
    ///   "InspectionMethod": "AOI",
    ///   "SamplingInformation": {
    ///     "SamplingMethod": "NoSampling",
    ///     "LotSize": null,
    ///     "SampleSize": null
    ///   },
    ///   "Inspector": {
    ///     "OperatorIdentifier": "UID235434324",
    ///     "ActorType": "Human",
    ///     "FullName": "Joseph Smith",
    ///     "LastName": "Smith",
    ///     "FirstName": "Joseph",
    ///     "LoginName": "joseph.smith@abcdrepairs.com"
    ///   },
    ///   "InspectedUnits": [
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "Passed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "75005046-747e-41db-b995-b439b50c3c5d",
    ///           "InspectionName": "INSPECT_R21",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": null,
    ///           "Measurements": []
    ///         },
    ///         {
    ///           "UniqueIdentifier": "45429ea9-a649-4d9d-8f79-31ee51a8032e",
    ///           "InspectionName": "INSPECT_R22",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": null,
    ///           "Measurements": []
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 2,
    ///       "OverallResult": "Failed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "e66be78a-b91e-49f8-b2e4-6df002331e49",
    ///           "InspectionName": "INSPECT_R21",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": null,
    ///           "Measurements": []
    ///         },
    ///         {
    ///           "UniqueIdentifier": "f53e0800-487e-48a6-961a-f4cf08f21e9b",
    ///           "InspectionName": "INSPECT_R22",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Failed",
    ///           "Error": null,
    ///           "DefectsFound": [
    ///             {
    ///               "UniqueIdentifier": "0924ab55-889d-45bd-a685-cd124fc519c9",
    ///               "DefectCode": "ISFSLD112",
    ///               "DefectCategory": "Solder Problems",
    ///               "Description": "Insuffiecient Solder on R22, Lead 1",
    ///               "Comments": null,
    ///               "ComponentOfInterest": {
    ///                 "ReferenceDesignator": "R22.1",
    ///                 "UnitPosition": null,
    ///                 "PartNumber": "11123-8897"
    ///               },
    ///               "RegionOfInterest": {
    ///                 "StartPointX": 0.0,
    ///                 "StartPointY": 0.0,
    ///                 "RegionSegments": []
    ///               },
    ///               "DefectImages": [
    ///                 {
    ///                   "MimeType": "image/jpg",
    ///                   "ImageData": "rFRWd9iZ"
    ///                 }
    ///               ],
    ///               "Priority": 1,
    ///               "ConfidenceLevel": 100.0,
    ///               "RelatedMeasurements": [],
    ///               "RelatedSymptoms": []
    ///             },
    ///             {
    ///               "UniqueIdentifier": "c2c7ff88-3725-4a1c-88cf-029f7fc38859",
    ///               "DefectCode": "TMBSTN211",
    ///               "DefectCategory": "Solder Problems",
    ///               "Description": "Tombston on R22",
    ///               "Comments": null,
    ///               "ComponentOfInterest": {
    ///                 "ReferenceDesignator": "R22",
    ///                 "UnitPosition": null,
    ///                 "PartNumber": "11123-8897"
    ///               },
    ///               "RegionOfInterest": {
    ///                 "StartPointX": 0.0,
    ///                 "StartPointY": 0.0,
    ///                 "RegionSegments": []
    ///               },
    ///               "DefectImages": [
    ///                 {
    ///                   "MimeType": "image/jpg",
    ///                   "ImageData": "XSjjh8i5"
    ///                 }
    ///               ],
    ///               "Priority": 1,
    ///               "ConfidenceLevel": 100.0,
    ///               "RelatedMeasurements": [],
    ///               "RelatedSymptoms": []
    ///             }
    ///           ],
    ///           "Symptoms": null,
    ///           "Measurements": []
    ///         },
    ///         {
    ///           "UniqueIdentifier": "5850e5d9-aae1-46dc-897f-a9c8733f72fb",
    ///           "InspectionName": "COSMETIC_INSPECTION",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Failed",
    ///           "Error": null,
    ///           "DefectsFound": [
    ///             {
    ///               "UniqueIdentifier": "6fb1a6b3-a29e-4a21-84d1-91d7b24f1a07",
    ///               "DefectCode": "SCR23443",
    ///               "DefectCategory": "Cosmetic Problems",
    ///               "Description": "Scratch Detected on PCB substrate",
    ///               "Comments": null,
    ///               "ComponentOfInterest": {
    ///                 "ReferenceDesignator": null,
    ///                 "UnitPosition": null,
    ///                 "PartNumber": null
    ///               },
    ///               "RegionOfInterest": {
    ///                 "StartPointX": 2.3,
    ///                 "StartPointY": 4.0,
    ///                 "RegionSegments": [
    ///                   {
    ///                     "X": 5.6,
    ///                     "Y": 4.0
    ///                   },
    ///                   {
    ///                     "X": 5.6,
    ///                     "Y": 1.6
    ///                   },
    ///                   {
    ///                     "X": 2.3,
    ///                     "Y": 1.6
    ///                   },
    ///                   {
    ///                     "X": 2.3,
    ///                     "Y": 4.0
    ///                   }
    ///                 ]
    ///               },
    ///               "DefectImages": [],
    ///               "Priority": 1,
    ///               "ConfidenceLevel": 100.0,
    ///               "RelatedMeasurements": [],
    ///               "RelatedSymptoms": []
    ///             }
    ///           ],
    ///           "Symptoms": null,
    ///           "Measurements": []
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>Solder Paste Inspection Example:</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "039e47b3-d176-4544-a289-ddb81c0c71a8",
    ///   "InspectionMethod": "SPI",
    ///   "SamplingInformation": {
    ///     "SamplingMethod": "NoSampling",
    ///     "LotSize": null,
    ///     "SampleSize": null
    ///   },
    ///   "Inspector": {
    ///     "OperatorIdentifier": "UID235434324",
    ///     "ActorType": "Human",
    ///     "FullName": "Joseph Smith",
    ///     "LastName": "Smith",
    ///     "FirstName": "Joseph",
    ///     "LoginName": "joseph.smith@abcdrepairs.com"
    ///   },
    ///   "InspectedUnits": [
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "Passed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "1d7e1cc3-09d5-49e2-869f-2b8712b7928a",
    ///           "InspectionName": "INSPECT_PASTE_DEPOSITIONS",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": null,
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "ComponentPad": "R1.1",
    ///               "PasteXSize": {
    ///                 "Value": 45.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 46.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 45.1,
    ///                 "MaximumAcceptableValue": 46.9
    ///               },
    ///               "PasteYSize": {
    ///                 "Value": 85.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 86.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 85.1,
    ///                 "MaximumAcceptableValue": 86.9
    ///               },
    ///               "PasteXOffset": {
    ///                 "Value": 0.2,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteYOffset": {
    ///                 "Value": 0.1,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteHeight": {
    ///                 "Value": 2.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 2.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 2.1,
    ///                 "MaximumAcceptableValue": 2.9
    ///               },
    ///               "PasteVolume": {
    ///                 "Value": 28.9,
    ///                 "ValueUnits": "ml",
    ///                 "ExpectedValue": 28.7,
    ///                 "ExpectedValueUnits": "ml",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 30.0
    ///               },
    ///               "DepositImage": {
    ///                 "MimeType": "image/jpg",
    ///                 "ImageData": "/z2Zhw=="
    ///               },
    ///               "UniqueIdentifier": "1cee0a74-ee24-42f0-bd94-63949b0475b1",
    ///               "MeasurementName": "MEASURE R1.1",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": null
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "ComponentPad": "R1.2",
    ///               "PasteXSize": {
    ///                 "Value": 45.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 46.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 45.1,
    ///                 "MaximumAcceptableValue": 46.9
    ///               },
    ///               "PasteYSize": {
    ///                 "Value": 85.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 86.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 85.1,
    ///                 "MaximumAcceptableValue": 86.9
    ///               },
    ///               "PasteXOffset": {
    ///                 "Value": 0.2,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteYOffset": {
    ///                 "Value": 0.1,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteHeight": {
    ///                 "Value": 2.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 2.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 2.1,
    ///                 "MaximumAcceptableValue": 2.9
    ///               },
    ///               "PasteVolume": {
    ///                 "Value": 28.9,
    ///                 "ValueUnits": "ml",
    ///                 "ExpectedValue": 28.7,
    ///                 "ExpectedValueUnits": "ml",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 30.0
    ///               },
    ///               "DepositImage": {
    ///                 "MimeType": "image/jpg",
    ///                 "ImageData": "/z2Zhw=="
    ///               },
    ///               "UniqueIdentifier": "953505f7-1fd3-4ed6-83cf-5f99fe3f3b6c",
    ///               "MeasurementName": "MEASURE R1.1",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": null
    ///             }
    ///           ]
    ///         }
    ///       ]
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL34543535",
    ///       "UnitPositionNumber": 2,
    ///       "OverallResult": "Failed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "4721c00a-b653-4a1a-9b63-724fe92c892a",
    ///           "InspectionName": "INSPECT_PASTE_DEPOSITIONS",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": null,
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "ComponentPad": "R1.1",
    ///               "PasteXSize": {
    ///                 "Value": 45.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 46.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 45.1,
    ///                 "MaximumAcceptableValue": 46.9
    ///               },
    ///               "PasteYSize": {
    ///                 "Value": 85.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 86.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 85.1,
    ///                 "MaximumAcceptableValue": 86.9
    ///               },
    ///               "PasteXOffset": {
    ///                 "Value": 0.2,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteYOffset": {
    ///                 "Value": 0.1,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteHeight": {
    ///                 "Value": 2.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 2.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 2.1,
    ///                 "MaximumAcceptableValue": 2.9
    ///               },
    ///               "PasteVolume": {
    ///                 "Value": 28.9,
    ///                 "ValueUnits": "ml",
    ///                 "ExpectedValue": 28.7,
    ///                 "ExpectedValueUnits": "ml",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 30.0
    ///               },
    ///               "DepositImage": null,
    ///               "UniqueIdentifier": "a49769d3-7a47-4fe6-af17-36dd3e132ce7",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": null
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "ComponentPad": "R1.2",
    ///               "PasteXSize": {
    ///                 "Value": 45.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 46.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 45.1,
    ///                 "MaximumAcceptableValue": 46.9
    ///               },
    ///               "PasteYSize": {
    ///                 "Value": 85.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 86.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 85.1,
    ///                 "MaximumAcceptableValue": 86.9
    ///               },
    ///               "PasteXOffset": {
    ///                 "Value": 0.2,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteYOffset": {
    ///                 "Value": 0.1,
    ///                 "ValueUnits": "um",
    ///                 "ExpectedValue": 0.0,
    ///                 "ExpectedValueUnits": "um",
    ///                 "MinimumAcceptableValue": -10.2,
    ///                 "MaximumAcceptableValue": 10.2
    ///               },
    ///               "PasteHeight": {
    ///                 "Value": 2.6,
    ///                 "ValueUnits": "mm",
    ///                 "ExpectedValue": 2.7,
    ///                 "ExpectedValueUnits": "mm",
    ///                 "MinimumAcceptableValue": 2.1,
    ///                 "MaximumAcceptableValue": 2.9
    ///               },
    ///               "PasteVolume": {
    ///                 "Value": 28.9,
    ///                 "ValueUnits": "ml",
    ///                 "ExpectedValue": 28.7,
    ///                 "ExpectedValueUnits": "ml",
    ///                 "MinimumAcceptableValue": 28.0,
    ///                 "MaximumAcceptableValue": 30.0
    ///               },
    ///               "DepositImage": null,
    ///               "UniqueIdentifier": "0ea8afc9-d347-4f66-8193-5f79f4d1f17a",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "Components": null
    ///             }
    ///           ]
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class UnitsInspected : CFXMessage
    {
        public UnitsInspected()
        {
            InspectedUnits = new List<InspectedUnit>();
            Inspector = new Operator();
            InspectionMethod = InspectionMethod.Human;
            SamplingInformation = new SamplingInformation();
        }

        /// <summary>
        /// The id of the work transaction with which this inspection session is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Describes how the inspections were performed
        /// </summary>
        public InspectionMethod InspectionMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Describes the sampling method that was used during the inspections (if any)
        /// </summary>
        public SamplingInformation SamplingInformation
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who performed the inspections, or operator of the automated equipment that performed the inspections
        /// </summary>
        public Operator Inspector
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the units that were inspected, along with the inspections made, 
        /// and inspection results.
        /// </summary>
        public List<InspectedUnit> InspectedUnits
        {
            get;
            set;
        }
    }
}
