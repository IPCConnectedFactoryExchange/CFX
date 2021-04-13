using System;
using System.Collections.Generic;
using System.Text;
using CFX;
using CFX.Structures;
using CFX.Structures.Maintenance;
using Newtonsoft.Json;

namespace CFX.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Dynamic response from external systems with detailed information about a resource maintenance status.
    /// This is typically used for resource that may undergo maintenance operations (e.g. SMTTapeFeederInformation)
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <code language="none">
    /// {
    ///   "Result": null,
    ///   "Machine": {
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SIPLACE SX4",
    ///     "Vendor": null,
    ///     "ModelNumber": null,
    ///     "SerialNumber": null,
    ///     "SoftwareVersion": null,
    ///     "FirmwareVersion": null
    ///   },
    ///   "ResourceMaintenanceDetails": [
    ///     {
    ///       "$type": "CFX.Structures.Maintenance.SMTTapeFeederInformation, CFX",
    ///       "MultiLanes": [
    ///         {
    ///           "CycleCount": 1002,
    ///           "LaneNumber": 1,
    ///           "UniqueIdentifier": "09ASMS500302_Lane_1"
    ///         },
    ///         {
    ///           "CycleCount": 3451,
    ///           "LaneNumber": 2,
    ///           "UniqueIdentifier": "09ASMS500302_Lane_2"
    ///         }
    ///       ],
    ///       "ResourceName": "8mm-X Tape_2.14",
    ///       "ResourceIdentifier": "08FAUT901183",
    ///       "ResourceType": "8mm-X Tape",
    ///       "ResourcePosition": "2.14",
    ///       "MaintenanceStatus": {
    ///         "Reason": "No reason",
    ///         "ResultState": "Ok"
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.3")]
    public class GetResourceMaintenanceStatusResponse : CFXMessage
    {
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
        /// NOTE: in case the resource is not attached to the endpoint / machine, this field shall be null
        /// </summary>
        public Resource Machine
        {
            get;
            set;
        }
       
        /// /// <summary>
        /// Dynamic structure that describes the response about maintenance details of this resource.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<ResourceInformation> ResourceMaintenanceDetails
        {
            get;
            set;
        }
    }
}
