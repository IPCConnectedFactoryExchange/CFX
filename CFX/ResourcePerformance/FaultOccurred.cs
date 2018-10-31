using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// <para>Sent by a process endpoint whenever a fault is encountered. A data structure must be included in the message related to specific equipment type.</para>
    /// <para>Generic Fault Example:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "ea170e0a-43fb-4b02-af2c-928a8401dd51",
    ///     "Lane": null,
    ///     "Stage": null,
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown",
    ///     "Description": null,
    ///     "DescriptionTranslations": {},
    ///     "OccurredAt": "2018-10-31T15:13:31.0083597-04:00",
    ///     "DueDateTime": null
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// <para>SMT Placement Fault Example:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "$type": "CFX.Structures.SMTPlacement.SMTPlacementFault, CFX",
    ///     "PlacementFaultType": "PickupError",
    ///     "ProgramStep": 56,
    ///     "Designator": {
    ///       "ReferenceDesignator": "R31",
    ///       "UnitPosition": null,
    ///       "PartNumber": "PN123456"
    ///     },
    ///     "MaterialLocation": {
    ///       "LocationIdentifier": "UID23948348324",
    ///       "LocationName": "SLOT47",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "UID34280923084932849",
    ///         "InternalPartNumber": "IPN456465465465",
    ///         "Quantity": 854.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": null,
    ///         "BaseName": null,
    ///         "LaneNumber": 1,
    ///         "TapeWidth": 8.0,
    ///         "TapePitch": 8.0,
    ///         "UniqueIdentifier": "FDR2348934-32890",
    ///         "Name": "8MMFDR231"
    ///       }
    ///     },
    ///     "HeadAndNozzle": {
    ///       "HeadId": "HEAD1",
    ///       "HeadNozzleNumber": 3,
    ///       "NozzleType": "TYPE914",
    ///       "UniqueIdentifier": "UID2389432849",
    ///       "Name": "NOZZLE3243244"
    ///     },
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "a5c05bdc-41a3-4e50-b421-b084eb12ba2b",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 2,
    ///       "StageName": "STAGE2",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown",
    ///     "Description": null,
    ///     "DescriptionTranslations": {},
    ///     "OccurredAt": "2018-10-31T15:13:31.0552292-04:00",
    ///     "DueDateTime": null
    ///   }
    /// }
    /// </code>
    /// <para>THT Insertion Fault Example:</para>
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "$type": "CFX.Structures.THTInsertion.THTInsertionFault, CFX",
    ///     "InsertionFaultType": "ClinchError",
    ///     "ProgramStep": 56,
    ///     "Designator": {
    ///       "ReferenceDesignator": "R31",
    ///       "UnitPosition": null,
    ///       "PartNumber": "PN123456"
    ///     },
    ///     "MaterialLocation": {
    ///       "LocationIdentifier": "UID23948348324",
    ///       "LocationName": "SLOT47",
    ///       "MaterialPackage": {
    ///         "UniqueIdentifier": "UID34280923084932849",
    ///         "InternalPartNumber": "IPN456465465465",
    ///         "Quantity": 854.0
    ///       },
    ///       "CarrierInformation": {
    ///         "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///         "BaseUniqueIdentifier": null,
    ///         "BaseName": null,
    ///         "LaneNumber": 1,
    ///         "TapeWidth": 8.0,
    ///         "TapePitch": 8.0,
    ///         "UniqueIdentifier": "FDR2348934-32890",
    ///         "Name": "8MMFDR231"
    ///       }
    ///     },
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "cdc5d80e-bd0a-4b3b-9d85-9084b23f95e5",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "STAGE2",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown",
    ///     "Description": null,
    ///     "DescriptionTranslations": {},
    ///     "OccurredAt": "2018-10-31T15:13:31.0708549-04:00",
    ///     "DueDateTime": null
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// <para>Solder Paste Printing Fault Example:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "$type": "CFX.Structures.SolderPastePrinting.SMTSolderPastePrintingFault, CFX",
    ///     "PrintingFaultType": "SqueegeeError",
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 234333",
    ///     "FaultOccurrenceId": "1610b591-eba0-4d30-b56e-89fdc94f865e",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "PRINTSTAGE",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown",
    ///     "Description": null,
    ///     "DescriptionTranslations": {},
    ///     "OccurredAt": "2018-10-31T15:13:31.1021044-04:00",
    ///     "DueDateTime": null
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class FaultOccurred : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FaultOccurred()
        {
            Fault = new Fault();
        }

        /// <summary>
        /// Dynamic structure providing detailed information about the fault that has occurred.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Fault Fault
        {
            get;
            set;
        }
    }
}
