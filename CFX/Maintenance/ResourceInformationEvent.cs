using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Maintenance
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.3 **</para>
    /// Allows any CFX endpoint to send the resource and sub-resources of a specified single endpoint. 
    /// The event can be sent "on change" or "time" base.
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Example for SMT Endpoint:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "EventDateTime": "2020-11-26T18:27:14+01:00",
    ///   "ResourceInformation": {
    ///     "$type": "CFX.Structures.Maintenance.MaintenanceResource, CFX",
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SMT SIPLACE SX 4",
    ///     "ResourceType": "SMT",
    ///     "Vendor": "ASM",
    ///     "ModelNumber": "SIPLACE SX4",
    ///     "SerialNumber": "UID1111111111111111",
    ///     "SoftwareVersion": "713",
    ///     "FirmwareVersion": null,
    ///     "Resources": [
    ///       {
    ///         "ResourceIdentifier": "10000000-00 000-G1-GC__",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "SST34_1",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "1.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000-00 000-G2-GC__",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "SST34_2",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "2.2",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000-00 000-G3-GC__",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "SST34_3",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "2.3",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000-00 000-G4-GC__",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "SST34_4",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "1.4",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_Conveyor_0_E_1",
    ///         "IdentiferUniqueness": "LocallyPersistent",
    ///         "ResourceName": "Dual",
    ///         "ResourceType": "Conveyor",
    ///         "ResourcePosition": null,
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_Gantry_X_1_R_1",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "Gantry_1",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_Gantry_X_2_R_1",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "Gantry_2",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "2.2",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_Gantry_X_2_L_1",
    ///         "IdentiferUniqueness": "Unkwnown",
    ///         "ResourceName": "Gantry_3",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "2.3",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_Gantry_X_1_L_1",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "Gantry_4",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.4",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_NozzleChanger_1_L_1",
    ///         "IdentiferUniqueness": "Unkwnown",
    ///         "ResourceName": "NozzleCarrier_14_4.1",
    ///         "ResourceType": "NozzleCarrier_14",
    ///         "ResourcePosition": "1.4.1.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_NozzleChanger_2_L_1",
    ///         "IdentiferUniqueness": "Unkwnown",
    ///         "ResourceName": "NozzleCarrier_10_3.1",
    ///         "ResourceType": "NozzleCarrier_10_3",
    ///         "ResourcePosition": "2.3.1.3",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "00000000-00 000-H1-_____",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "C&amp;P20_1",
    ///         "ResourceType": "C&amp;P20",
    ///         "ResourcePosition": "1.1.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null,
    ///         "Cameras": [
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H1-HC__",
    ///             "IdentiferUniqueness": "GloballyPersistent",
    ///             "ResourceName": "SST23_1.1",
    ///             "ResourceType": "SST23",
    ///             "ResourcePosition": "1.1.1",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           }
    ///         ],
    ///         "RotationAxes": [
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H1-DP1_",
    ///             "IdentiferUniqueness": "LocallyPersistent",
    ///             "ResourceName": "C&amp;P20_1_DpAxis1",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "1.1.1.1",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           },
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H1-DP10",
    ///             "IdentiferUniqueness": "LocallyPersistent",
    ///             "ResourceName": "C&amp;P20_1_DpAxis10",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "1.1.1.10",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           }
    ///         ]
    ///       },
    ///       {
    ///         "ResourceIdentifier": "00000000-00 000-H3-_____",
    ///         "IdentiferUniqueness": "GloballyPersistent",
    ///         "ResourceName": "C&amp;P20_3",
    ///         "ResourceType": "C&amp;P20",
    ///         "ResourcePosition": "2.3.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null,
    ///         "Cameras": [
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H3-HC__",
    ///             "IdentiferUniqueness": "GloballyPersistent",
    ///             "ResourceName": "SST23_3.1",
    ///             "ResourceType": "SST23",
    ///             "ResourcePosition": "2.3.1",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           }
    ///         ],
    ///         "RotationAxes": [
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H3-DP1_",
    ///             "IdentiferUniqueness": "LocallyPersistent",
    ///             "ResourceName": "C&amp;P20_3_DpAxis1",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "2.3.1.1",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           },
    ///           {
    ///             "ResourceIdentifier": "10000000-00 000-H3-DP10",
    ///             "IdentiferUniqueness": "LocallyPersistent",
    ///             "ResourceName": "C&amp;P20_3_DpAxis10",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "2.3.1.10",
    ///             "MaintenanceStatus": null,
    ///             "AdditionalSubResources": null
    ///           }
    ///         ]
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_TapeCutter_1_L_1",
    ///         "IdentiferUniqueness": "UnserializedLocation",
    ///         "ResourceName": "TapeCutter_1.4",
    ///         "ResourceType": "",
    ///         "ResourcePosition": "1.0.4",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       },
    ///       {
    ///         "ResourceIdentifier": "10000000_TapeCutter_1_R_1",
    ///         "IdentiferUniqueness": "UnserializedLocation",
    ///         "ResourceName": "TapeCutter_1.1",
    ///         "ResourceType": "",
    ///         "ResourcePosition": "1.0.1",
    ///         "MaintenanceStatus": null,
    ///         "AdditionalSubResources": null
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// </summary>

    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ResourceInformationEvent : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ResourceInformationEvent()
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
        public Resource ResourceInformation
        {
            get;
            set;
        }
    }
}
