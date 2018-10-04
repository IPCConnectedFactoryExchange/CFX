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
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "731ce619-7e80-4bf0-bb82-2985a9fa7368",
    ///     "Lane": null,
    ///     "Stage": null
    ///   }
    /// }
    /// </code>
    /// <para>SMT Placement Fault Example:</para>
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
    ///     "Nozzle": {
    ///       "HeadId": "HEAD1",
    ///       "HeadNozzleNumber": 3,
    ///       "NozzleType": "TYPE914",
    ///       "UniqueIdentifier": "UID2389432849",
    ///       "Name": "NOZZLE3243244"
    ///     },
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 3943480",
    ///     "FaultOccurrenceId": "1806f0fa-ea40-4533-b951-eb74fb13f240",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 2,
    ///       "StageName": "STAGE2",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown"
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
    ///     "FaultOccurrenceId": "6367fdee-232c-4976-9254-6ea8861f516e",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "STAGE2",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown"
    ///   }
    /// }
    /// </code>
    /// <para>Solder Paste Printing Fault Example:</para>
    /// <code language="none">
    /// {
    ///   "Fault": {
    ///     "$type": "CFX.Structures.SolderPastePrinting.SMTSolderPastePrintingFault, CFX",
    ///     "PrintingFaultType": "SqueegeeError",
    ///     "Cause": "MechanicalFailure",
    ///     "Severity": "Error",
    ///     "FaultCode": "ERROR 234333",
    ///     "FaultOccurrenceId": "024f9e24-7e4f-4eb7-8ab1-2e16a74891fa",
    ///     "Lane": 1,
    ///     "Stage": {
    ///       "StageSequence": 1,
    ///       "StageName": "PRINTSTAGE",
    ///       "StageType": "Work"
    ///     },
    ///     "SideLocation": "Unknown",
    ///     "AccessType": "Unknown"
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class FaultOccurred : CFXMessage
    {
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
