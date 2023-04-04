using CFX.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Production.TestAndInspection
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.7 **</para>
    /// Response from a process endpoint to a request to obtatin Inspection information for a list of Unit
    /// <code language="none">
    /// {
    ///   "InspectedUnits": [
    ///     {
    ///       "UnitIdentifier": "SN123456",
    ///       "UnitPositionNumber": 1,
    ///       "OverallResult": "Passed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "INS000001",
    ///           "InspectionName": null,
    ///           "InspectionStartTime": "2023-04-04T11:42:50.582574+02:00",
    ///           "InspectionEndTime": "2023-04-04T11:44:08.582574+02:00",
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Verification": "NotVerifiedYet",
    ///           "VerificationDetail": null,
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": [],
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "X": 0.0,
    ///               "EX": 0.8,
    ///               "Y": 0.0,
    ///               "EY": 1.5,
    ///               "Z": 0.0,
    ///               "EZ": 0.0,
    ///               "DX": 0.0,
    ///               "DY": 0.0,
    ///               "Vol": 0.0,
    ///               "EVol": 0.0001,
    ///               "Image": null,
    ///               "A": 0.0,
    ///               "EA": 1.2,
    ///               "PX": 3000.0,
    ///               "PY": 1200.0,
    ///               "RXY": 0.0,
    ///               "AR": 1.8,
    ///               "UniqueIdentifier": "MS00001",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Failed",
    ///               "CRDs": "R1,R2,R3.1"
    ///             }
    ///           ],
    ///           "RefNo": null
    ///         }
    ///       ],
    ///       "Verification": "NotVerifiedYet",
    ///       "TotalInspectionCount": 1
    ///     },
    ///     {
    ///       "UnitIdentifier": "SN9012345",
    ///       "UnitPositionNumber": 2,
    ///       "OverallResult": "Passed",
    ///       "Inspections": [
    ///         {
    ///           "UniqueIdentifier": "INS000002",
    ///           "InspectionName": null,
    ///           "InspectionStartTime": "2023-04-04T11:42:50.582574+02:00",
    ///           "InspectionEndTime": "2023-04-04T11:43:56.582574+02:00",
    ///           "TestProcedure": null,
    ///           "Comments": null,
    ///           "Result": "Passed",
    ///           "Verification": "NotVerifiedYet",
    ///           "VerificationDetail": null,
    ///           "Error": null,
    ///           "DefectsFound": [],
    ///           "Symptoms": [],
    ///           "Measurements": [
    ///             {
    ///               "$type": "CFX.Structures.SolderPasteInspection.SolderPasteMeasurement, CFX",
    ///               "X": 0.0,
    ///               "EX": 0.8,
    ///               "Y": 0.0,
    ///               "EY": 1.5,
    ///               "Z": 0.0,
    ///               "EZ": 0.0,
    ///               "DX": 0.0,
    ///               "DY": 0.0,
    ///               "Vol": 0.0,
    ///               "EVol": 0.0001,
    ///               "Image": null,
    ///               "A": 0.0,
    ///               "EA": 1.2,
    ///               "PX": 3000.0,
    ///               "PY": 1200.0,
    ///               "RXY": 0.0,
    ///               "AR": 1.8,
    ///               "UniqueIdentifier": "MS00002",
    ///               "MeasurementName": null,
    ///               "TimeRecorded": null,
    ///               "Sequence": 0,
    ///               "Result": "Failed",
    ///               "CRDs": "R5,R6,R7.1"
    ///             }
    ///           ],
    ///           "RefNo": null
    ///         }
    ///       ],
    ///       "Verification": "NotVerifiedYet",
    ///       "TotalInspectionCount": 1
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.7")]
    public class GetInspectionInfoResponse : CFXMessage
    {
        ///<summary>
        /// List of Units with the requested inspection results 
        /// </summary>
        public List<InspectedUnit> InspectedUnits
        {
            get;
            set;
        }
    }
}
