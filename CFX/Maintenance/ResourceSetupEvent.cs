using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Maintenance
{
    /// <summary>
    /// Allows any CFX endpoint to send data about the resource and sub-resources setup. 
    /// The event can be sent "on change" or "time" base.
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "EventDateTime": "2020-11-16T14:21:31+01:00",
    ///   "ResourceSetup": {
    ///     "$type": "CFX.Structures.Maintenance.SMTPlacementSetup, CFX",
    ///     "NozzleChangerGarages": [
    ///       {
    ///         "ResourceName": "10000000_NozzleChanger_1_L_1_1_2_2_1006",
    ///         "ResourceIdentifier": "10000000_466",
    ///         "ResourceType": "1006",
    ///         "ResourcePosition": "4.1.2.2",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "10000000_NozzleChanger_1_L_1_1_2_1_1006",
    ///         "ResourceIdentifier": "10000000_467",
    ///         "ResourceType": "1006",
    ///         "ResourcePosition": "4.1.2.1",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "Tables": [
    ///       {
    ///         "ResourceName": "Table_4",
    ///         "ResourceIdentifier": "10000000_FeederDevice_1_L",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "4.1.1",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "Table_1",
    ///         "ResourceIdentifier": "10000000_FeederDevice_1_R",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.1.1",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "Feeders": [
    ///       {
    ///         "MultiLanes": [
    ///           {
    ///             "CycleCount": null,
    ///             "LaneNumber": 1,
    ///             "UniqueIdentifier": "08ASMS500240_1"
    ///           }
    ///         ],
    ///         "ResourceName": "8mm-X Tape_2.40",
    ///         "ResourceIdentifier": "08ASMS500240",
    ///         "ResourceType": "8mm-X Tape",
    ///         "ResourcePosition": "2.40",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "MultiLanes": [
    ///           {
    ///             "CycleCount": null,
    ///             "LaneNumber": 1,
    ///             "UniqueIdentifier": "09ASMS500302_Lane_1"
    ///           },
    ///           {
    ///             "CycleCount": null,
    ///             "LaneNumber": 2,
    ///             "UniqueIdentifier": "09ASMS500302_Lane_2"
    ///           }
    ///         ],
    ///         "ResourceName": "2x8mm-X Tape_3.2",
    ///         "ResourceIdentifier": "09ASMS500302",
    ///         "ResourceType": "2x8mm-X Tape",
    ///         "ResourcePosition": "3.2",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SIPLACE SX4",
    ///     "Vendor": null,
    ///     "ModelNumber": null,
    ///     "SerialNumber": null,
    ///     "SoftwareVersion": null,
    ///     "FirmwareVersion": null
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ResourceSetupEvent : CFXMessage
    {
        /// <summary>
        /// Default constructor for the ResourceSetupEvent
        /// </summary>
        public ResourceSetupEvent()
        {
           
        }
        /// <summary>
        /// The date time of the event
        /// </summary>
        public DateTime? EventDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// Dynamic structure that describes the details of this resource.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public  Resource ResourceSetup
        {
            get;
            set;
        }
    }
}
