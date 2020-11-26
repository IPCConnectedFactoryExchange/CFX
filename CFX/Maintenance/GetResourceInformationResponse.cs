﻿using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.Maintenance
{
    /// <summary>
    /// Allows any CFX endpoint to request the resource and sub-resources of a specified single endpoint. 
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
    ///   "ResourceInformation": {
    ///     "$type": "CFX.Structures.Maintenance.SMTPlacementResource, CFX",
    ///     "Cameras": [
    ///       {
    ///         "ResourceName": "SST34_1",
    ///         "ResourceIdentifier": "10000000-00 000-G1-GC__",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "1.1",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "SST34_2",
    ///         "ResourceIdentifier": "10000000-00 000-G2-GC__",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "2.2",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "SST34_3",
    ///         "ResourceIdentifier": "10000000-00 000-G3-GC__",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "2.3",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "SST34_4",
    ///         "ResourceIdentifier": "10000000-00 000-G4-GC__",
    ///         "ResourceType": "SST34",
    ///         "ResourcePosition": "1.4",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "Conveyors": [
    ///       {
    ///         "ResourceName": "Dual",
    ///         "ResourceIdentifier": "10000000_Conveyor_0_E_1",
    ///         "ResourceType": "Dual",
    ///         "ResourcePosition": null,
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "ElectricCards": [],
    ///     "Gantries": [
    ///       {
    ///         "ResourceName": "Gantry_1",
    ///         "ResourceIdentifier": "10000000_Gantry_X_1_R_1",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.1",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "Gantry_2",
    ///         "ResourceIdentifier": "10000000_Gantry_X_2_R_1",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "2.2",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "Gantry_3",
    ///         "ResourceIdentifier": "10000000_Gantry_X_2_L_1",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "2.3",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "Gantry_4",
    ///         "ResourceIdentifier": "10000000_Gantry_X_1_L_1",
    ///         "ResourceType": null,
    ///         "ResourcePosition": "1.4",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "NozzleChangers": [
    ///       {
    ///         "ResourceName": "NozzleCarrier_14_4.1",
    ///         "ResourceIdentifier": "10000000_NozzleChanger_1_L_1",
    ///         "ResourceType": "NozzleCarrier_14",
    ///         "ResourcePosition": "1.4.1.1",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "NozzleCarrier_10_3.1",
    ///         "ResourceIdentifier": "10000000_NozzleChanger_2_L_1",
    ///         "ResourceType": "NozzleCarrier_10_3",
    ///         "ResourcePosition": "2.3.1.3",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "PlacementHeads": [
    ///       {
    ///         "Cameras": [
    ///           {
    ///             "ResourceName": "SST23_1.1",
    ///             "ResourceIdentifier": "10000000-00 000-H1-HC__",
    ///             "ResourceType": "SST23",
    ///             "ResourcePosition": "1.1.1",
    ///             "MaintenanceStatus": null
    ///           }
    ///         ],
    ///         "RotationAxes": [
    ///           {
    ///             "ResourceName": "C&P20_1_DpAxis1",
    ///             "ResourceIdentifier": "10000000-00 000-H1-DP1_",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "1.1.1.1",
    ///             "MaintenanceStatus": null
    ///           },
    ///           {
    ///             "ResourceName": "C&P20_1_DpAxis10",
    ///             "ResourceIdentifier": "10000000-00 000-H1-DP10",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "1.1.1.10",
    ///             "MaintenanceStatus": null
    ///           }
    ///         ],
    ///         "ResourceName": "C&P20_1",
    ///         "ResourceIdentifier": "00000000-00 000-H1-_____",
    ///         "ResourceType": "C&P20",
    ///         "ResourcePosition": "1.1.1",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "Cameras": [
    ///           {
    ///             "ResourceName": "SST23_3.1",
    ///             "ResourceIdentifier": "10000000-00 000-H3-HC__",
    ///             "ResourceType": "SST23",
    ///             "ResourcePosition": "2.3.1",
    ///             "MaintenanceStatus": null
    ///           }
    ///         ],
    ///         "RotationAxes": [
    ///           {
    ///             "ResourceName": "C&P20_3_DpAxis1",
    ///             "ResourceIdentifier": "10000000-00 000-H3-DP1_",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "2.3.1.1",
    ///             "MaintenanceStatus": null
    ///           },
    ///           {
    ///             "ResourceName": "C&P20_3_DpAxis10",
    ///             "ResourceIdentifier": "10000000-00 000-H3-DP10",
    ///             "ResourceType": null,
    ///             "ResourcePosition": "2.3.1.10",
    ///             "MaintenanceStatus": null
    ///           }
    ///         ],
    ///         "ResourceName": "C&C&P20_3",
    ///         "ResourceIdentifier": "00000000-00 000-H3-_____",
    ///         "ResourceType": "C&P20",
    ///         "ResourcePosition": "2.3.1",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "TapeCutters": [
    ///       {
    ///         "ResourceName": "TapeCutter_1.4",
    ///         "ResourceIdentifier": "10000000_TapeCutter_1_L_1",
    ///         "ResourceType": "",
    ///         "ResourcePosition": "1.0.4",
    ///         "MaintenanceStatus": null
    ///       },
    ///       {
    ///         "ResourceName": "TapeCutter_1.1",
    ///         "ResourceIdentifier": "10000000_TapeCutter_1_R_1",
    ///         "ResourceType": "",
    ///         "ResourcePosition": "1.0.1",
    ///         "MaintenanceStatus": null
    ///       }
    ///     ],
    ///     "VacuumPumps": [],
    ///     "UniqueIdentifier": "10000000",
    ///     "Name": "SMT SIPLACE SX 4",
    ///     "Vendor": "ASM",
    ///     "ModelNumber": "SIPLACE SX4",
    ///     "SerialNumber": "UID1111111111111111",
    ///     "SoftwareVersion": "713",
    ///     "FirmwareVersion": null
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// </summary>

    [CFX.Utilities.CreatedVersion("1.3")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetResourceInformationResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetResourceInformationResponse()
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
