using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;
using CFX.Structures.Maintenance;

namespace CFX.Maintenance
{
    /// <summary>
    /// Allows any CFX endpoint to request the resource and sub-resources setup of a specified single endpoint. 
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "ResourceSetup": {
    ///     "$type": "CFX.Structures.SMTPlacement.SMTPlacementSetup, CFX",
    ///     "NozzleChangerGarages": [
    ///       {
    ///         "ResourceName": "10000000_NozzleChanger_1_L_1_1_2_2_1006",
    ///         "ResourceIdentifier": "10000000_466",
    ///         "ResourceType": "1006",
    ///         "ResourcePosition": "4.1.2.2"
    ///       },
    ///       {
    ///         "ResourceName": "10000000_NozzleChanger_1_L_1_1_2_1_1006",
    ///         "ResourceIdentifier": "10000000_467",
    ///         "ResourceType": "1006",
    ///         "ResourcePosition": "4.1.2.1"
    ///       }
    ///     ],
    ///     "Tables": [
    ///       {
    ///         "ResourceName": "Table_4",
    ///         "ResourceIdentifier": "10000000_FeederDevice_1_L",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "4.1.1"
    ///       },
    ///       {
    ///         "ResourceName": "Table_1",
    ///         "ResourceIdentifier": "10000000_FeederDevice_1_R",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.1.1"
    ///       }
    ///     ],
    ///     "FeederLocations": [
    ///       {
    ///         "LocationIdentifier": "3.2",
    ///         "LocationName": "Location name",
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "09ASMS500302",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 0.0,
    ///           "TapePitch": 0.0,
    ///           "UniqueIdentifier": "09ASMS500302",
    ///           "Name": "2x8mm-X Tape_3.2"
    ///         }
    ///       },
    ///       {
    ///         "LocationIdentifier": "4.7",
    ///         "LocationName": "Location name",
    ///         "CarrierInformation": {
    ///           "$type": "CFX.Structures.SMTPlacement.SMDTapeFeeder, CFX",
    ///           "BaseUniqueIdentifier": "08ASMS500407",
    ///           "BaseName": null,
    ///           "LaneNumber": 1,
    ///           "TapeWidth": 0.0,
    ///           "TapePitch": 0.0,
    ///           "UniqueIdentifier": "08ASMS500407",
    ///           "Name": "8mm-X Tape_4.7"
    ///         }
    ///       }
    ///     ],
    ///     "UniqueIdentifier": null,
    ///     "Name": null
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetResourceMaintenanceAndServiceResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetResourceMaintenanceAndServiceResponse()
        {
            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }
        /// <summary>
        /// The barcode, RFID, or other unique identifier that is used to identify this machine / endpoint.
        /// </summary>
        public string UniqueIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// Dynamic structure that describes the details of this maintenance and service.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public  List<ServiceAndMaintenanceData> MachineServiceAndMaintenanceData
        {
            get;
            set;
        }
    }
}
