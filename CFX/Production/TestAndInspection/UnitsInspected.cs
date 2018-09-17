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
    /// <para>  </para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "bc799894-c0dc-4373-bddd-8259b78eb082",
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
    ///           "UniqueIdentifier": "83326aff-050b-4483-a43b-3faf000c5a40",
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
    ///           "UniqueIdentifier": "8c33b186-e8db-410b-af3c-d6a90cfb1610",
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
    ///           "UniqueIdentifier": "c121fe35-db2f-44aa-9a37-59661cc11ed7",
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
    ///           "UniqueIdentifier": "13cc5da1-b257-41fc-89f7-e908ef3afff3",
    ///           "InspectionName": "INSPECT_R22",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Failed",
    ///           "Error": null,
    ///           "DefectsFound": [
    ///             {
    ///               "UniqueIdentifier": "0006e95c-5eb6-4fbe-a456-0ce6b269e525",
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
    ///               "UniqueIdentifier": "33493e20-7e22-47c7-8f03-26e2512d2222",
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
    ///           "UniqueIdentifier": "4413185d-8541-4e70-ae7e-0b8c7b15a661",
    ///           "InspectionName": "COSMETIC_INSPECTION",
    ///           "InspectionStartTime": null,
    ///           "InspectionEndTime": null,
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Failed",
    ///           "Error": null,
    ///           "DefectsFound": [
    ///             {
    ///               "UniqueIdentifier": "f8c206b7-0be1-4717-a3d3-c93bc4421568",
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
    /// <para>  </para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "5c36dbd0-fd6b-4463-ad79-7ca5c4498b56",
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
    ///           "UniqueIdentifier": "833c6606-aad9-4d04-aaea-af1ccbd7f6bd",
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
    ///               "X": 5.62,
    ///               "EX": 5.6,
    ///               "Y": 8.29,
    ///               "EY": 8.3,
    ///               "Z": 5.01,
    ///               "EZ": 5.0,
    ///               "DX": 0.02,
    ///               "DY": 0.03,
    ///               "Vol": 5.11,
    ///               "EVol": 5.1,
    ///               "Image": null,
    ///               "UniqueIdentifier": "29496f49-e06d-4aa7-8441-c5b0931fe366",
    ///               "MeasurementName": "R1.1",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1.1"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "X": 5.62,
    ///               "EX": 5.6,
    ///               "Y": 8.29,
    ///               "EY": 8.3,
    ///               "Z": 5.01,
    ///               "EZ": 5.0,
    ///               "DX": 0.02,
    ///               "DY": 0.03,
    ///               "Vol": 5.11,
    ///               "EVol": 5.1,
    ///               "Image": null,
    ///               "UniqueIdentifier": "9d94c6dc-4b64-4e29-b338-9f1fa7653bc4",
    ///               "MeasurementName": "R1.2",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1.1"
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
    ///           "UniqueIdentifier": "71f64821-9883-43b4-bb28-fbf2125c23ca",
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
    ///               "X": 5.62,
    ///               "EX": 5.6,
    ///               "Y": 8.29,
    ///               "EY": 8.3,
    ///               "Z": 5.01,
    ///               "EZ": 5.0,
    ///               "DX": 0.02,
    ///               "DY": 0.03,
    ///               "Vol": 5.11,
    ///               "EVol": 5.1,
    ///               "Image": null,
    ///               "UniqueIdentifier": "a4aa1046-efb9-4213-ac9a-2e545ac6d9ba",
    ///               "MeasurementName": "R1.1",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1.1"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "X": 5.62,
    ///               "EX": 5.6,
    ///               "Y": 8.29,
    ///               "EY": 8.3,
    ///               "Z": 5.01,
    ///               "EZ": 5.0,
    ///               "DX": 0.02,
    ///               "DY": 0.03,
    ///               "Vol": 5.11,
    ///               "EVol": 5.1,
    ///               "Image": null,
    ///               "UniqueIdentifier": "774816fd-3396-47da-9d17-898bf3457494",
    ///               "MeasurementName": "R1.2",
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1.1"
    ///             }
    ///           ]
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>AOI Measuring Component Offsets Example:</para>
    /// <para>  </para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "5c5d54b0-90f9-41db-833d-a9499f4d191a",
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
    ///           "UniqueIdentifier": "87480b45-e1b8-4ec3-a72c-69ee4eaf149e",
    ///           "InspectionName": "INSPECT_COMPONENT_OFFSETS",
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
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "6240e370-a83d-4a2f-a0dd-3b9725347adc",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "ad87bc5c-f760-4f15-a18d-d11a655db211",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R2"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "9f8d6b81-55ac-4e94-bd54-f302266cafb5",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R3"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "533c3b13-b6cd-4513-b6f5-62936d7011dd",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R4"
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
    ///           "UniqueIdentifier": "8b616c57-cd3b-4c99-9566-7aa4886c4de0",
    ///           "InspectionName": "INSPECT_COMPONENT_OFFSETS",
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
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "38e2d7ec-6b01-4b8f-9a7e-c01d4481f771",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R1"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "3fb29677-74e7-4088-b1be-8b6fd8251b1c",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R2"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "bb3c9e82-6fdd-4257-9a8c-d981e11ad3e7",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R3"
    ///             },
    ///             {
    ///               "$type": "CFX.Structures.PCBInspection.OffsetMeasurement, CFX",
    ///               "DX": 0.02,
    ///               "DY": 0.01,
    ///               "DZ": 0.01,
    ///               "RXY": 0.01,
    ///               "RZX": 0.15,
    ///               "RZY": 0.15,
    ///               "UniqueIdentifier": "8b6860c0-809c-404a-a0ee-1978777b8117",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Passed",
    ///               "CRDs": "R4"
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
