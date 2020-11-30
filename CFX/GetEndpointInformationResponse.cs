using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX
{
    /// <summary>
    /// Allows any CFX endpoint to request the capabilities of a specified single endpoint. The response
    /// includes information about the endpoint, including its CFX Handle, and network hostname / address.
    /// The endpoint information structure is a dynamic structure, and can vary based on the type of endpoint.
    /// <para></para>
    /// Generic example:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "EndpointInformation": {
    ///     "CFXHandle": "SMTPlus.Model_21232.SN23123",
    ///     "CFXVersion": "1.0",
    ///     "RequestNetworkUri": "amqp://host55:5688/",
    ///     "RequestTargetAddress": "/queue/SN23123",
    ///     "UniqueIdentifier": "UID1111111111111111",
    ///     "FriendlyName": "SMD Printer 23123",
    ///     "Vendor": "SMT Plus",
    ///     "ModelNumber": "Model_11111",
    ///     "SerialNumber": "SNSN23123",
    ///     "SoftwareVersion": "18.5.4",
    ///     "FirmwareVersion": "1.6.13",
    ///     "OperatingSystem": "UbuntuLinux",
    ///     "OperatingSystemPlatform" : "Platform64bit",
    ///     "OperatingSystemVersion" : "18.04.4",
    ///     "Stages": [
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 1,
    ///           "StageName": "INBOUND BUFFER",
    ///           "StageType": "Buffer"
    ///         }
    ///       },
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 2,
    ///           "StageName": "WORK STAGE 1",
    ///           "StageType": "Work"
    ///         }
    ///       },
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 3,
    ///           "StageName": "OUTBOUND BUFFER",
    ///           "StageType": "Buffer"
    ///         }
    ///       }
    ///     ],
    ///     "NumberOfLanes": 1,
    ///     "HermesInformation": {
    ///       "Enabled": true,
    ///       "Version": "1.0"
    ///     },
    ///     "OperatingRequirements": {
    ///       "MinimumHumidity": 0.0,
    ///       "MaximumHumidity": 0.8,
    ///       "MinimumTemperature": -1.0,
    ///       "MaximumTemperature": 40.0
    ///     },
    ///     "SupportedTopics": [
    ///       {
    ///         "TopicName": "CFX.Production",
    ///         "TopicSupportType": "PublisherConsumer",
    ///         "SupportedMessages": []
    ///       },
    ///       {
    ///         "TopicName": "CFX.Production.Application",
    ///         "TopicSupportType": "Publisher",
    ///         "SupportedMessages": []
    ///       },
    ///       {
    ///         "TopicName": "CFX.ResourcePerformance",
    ///         "TopicSupportType": "Publisher",
    ///         "SupportedMessages": []
    ///       }
    ///     ],
    ///     "SleepStates": [
    ///         {
    ///             "SleepType": "Awake",            
    ///             "PowerSaving": 0,
    ///             "WakeupTime": 0
    ///         },
    ///         {
    ///             "SleepType": "Shallow",            
    ///             "PowerSaving": 10,
    ///             "WakeupTime": 30
    ///         },
    ///         {
    ///             "SleepType": "Sleep",            
    ///             "PowerSaving": 60,
    ///             "WakeupTime": 120
    ///         },
    ///         {
    ///             "SleepType": "Hibernate",            
    ///             "PowerSaving": 95,
    ///             "WakeupTime": 600
    ///         }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// <para></para>
    /// <para>Example of SMT Placement Machine type endpoint:</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": {
    ///     "Result": "Success",
    ///     "ResultCode": 0,
    ///     "Message": null
    ///   },
    ///   "EndpointInformation": {
    ///     "$type": "CFX.Structures.SMTPlacement.SMTPlacementEndpoint, CFX",
    ///     "NominalPlacementCPH": 10000.0,
    ///     "NominalUnitsPerHour": 120.0,
    ///     "SupportedPCBDimensions": {
    ///       "MinimumLength": 10.0,
    ///       "MaximumLength": 1000.0,
    ///       "MinimumWidth": 10.0,
    ///       "MaximumWidth": 1000.0,
    ///       "MinimumHeight": 0.0,
    ///       "MaximumHeight": 50.0,
    ///       "MinimumWeight": 0.0,
    ///       "MaximumWeight": 1000.0,
    ///       "MinimumThickness": 0.5,
    ///       "MaximumThickness": 10.0
    ///     },
    ///     "Lanes": [
    ///       {
    ///         "LaneNumber": null,
    ///         "LaneName": "LANE1",
    ///         "SupportedPCBDimensions": null
    ///       },
    ///       {
    ///         "LaneNumber": null,
    ///         "LaneName": "LANE2",
    ///         "SupportedPCBDimensions": null
    ///       }
    ///     ],
    ///     "Heads": [
    ///       {
    ///         "SMTHeadType": "Pulsar",
    ///         "NumberOfNozzleLocations": 6,
    ///         "PlacementAccuracy": 0.001,
    ///         "Head": {
    ///           "HeadId": "HD212343",
    ///           "HeadSequence": 1,
    ///           "HeadName": "HEAD1"
    ///         }
    ///       },
    ///       {
    ///         "SMTHeadType": "Pulsar",
    ///         "NumberOfNozzleLocations": 6,
    ///         "PlacementAccuracy": 0.001,
    ///         "Head": {
    ///           "HeadId": "HD212344",
    ///           "HeadSequence": 2,
    ///           "HeadName": "HEAD2"
    ///         }
    ///       }
    ///     ],
    ///     "PlacementConstraints": {
    ///       "MinumumComponentBodySizeX": 0.0,
    ///       "MaximumComponentBodySizeX": 0.0,
    ///       "MinumumComponentBodySizeY": 0.0,
    ///       "MaximumComponentBodySizeY": 0.0,
    ///       "MinumumComponentHeight": 0.0,
    ///       "MaximumComponentHeight": 0.0,
    ///       "MinimumLeadWidth": 0.0,
    ///       "MinimumBGAPitch": 0.0,
    ///       "MinimumSOICPitch": 0.0,
    ///       "MinimumMountingPressure": 0.0,
    ///       "MaximumMountingPressure": 0.0
    ///     },
    ///     "CFXHandle": "SMTPlus.Model_21232.SN23123",
    ///     "CFXVersion": "1.0",
    ///     "RequestNetworkUri": "amqp://host33:5688/",
    ///     "RequestTargetAddress": "/queue/SN23123",
    ///     "UniqueIdentifier": "UID564545645645656564",
    ///     "FriendlyName": "SMD Placer 23123",
    ///     "Vendor": "SMT Plus",
    ///     "ModelNumber": "Model_21232",
    ///     "SerialNumber": "SN23123",
    ///     "SoftwareVersion": "14.1.3",
    ///     "FirmwareVersion": "1.5.22",
    ///     "OperatingSystem": "Windows10",
    ///     "OperatingSystemPlatform" : "Platform64bit",
    ///     "OperatingSystemVersion" : "1809",
    ///     "Stages": [
    ///       {
    ///         "$type": "CFX.Structures.SMTPlacement.SMTStageInformation, CFX",
    ///         "NumberOfFeederStations": 0,
    ///         "Stage": {
    ///           "StageSequence": 1,
    ///           "StageName": "BUFFERSTAGE1",
    ///           "StageType": "Buffer"
    ///         }
    ///       },
    ///       {
    ///         "$type": "CFX.Structures.SMTPlacement.SMTStageInformation, CFX",
    ///         "NumberOfFeederStations": 100,
    ///         "Stage": {
    ///           "StageSequence": 2,
    ///           "StageName": "WORKSTAGE1",
    ///           "StageType": "Work"
    ///         }
    ///       },
    ///       {
    ///         "$type": "CFX.Structures.SMTPlacement.SMTStageInformation, CFX",
    ///         "NumberOfFeederStations": 100,
    ///         "Stage": {
    ///           "StageSequence": 3,
    ///           "StageName": "WORKSTAGE2",
    ///           "StageType": "Work"
    ///         }
    ///       }
    ///     ],
    ///     "NumberOfLanes": 1,
    ///     "HermesInformation": {
    ///       "Enabled": true,
    ///       "Version": "1.0"
    ///     },
    ///     "OperatingRequirements": {
    ///       "MinimumHumidity": 0.0,
    ///       "MaximumHumidity": 0.8,
    ///       "MinimumTemperature": -1.0,
    ///       "MaximumTemperature": 40.0
    ///     },
    ///     "SupportedTopics": [
    ///       {
    ///         "TopicName": "CFX.Production",
    ///         "TopicSupportType": "PublisherConsumer",
    ///         "SupportedMessages": []
    ///       },
    ///       {
    ///         "TopicName": "CFX.Production.Assembly",
    ///         "TopicSupportType": "Publisher",
    ///         "SupportedMessages": []
    ///       },
    ///       {
    ///         "TopicName": "CFX.ResourcePerformance",
    ///         "TopicSupportType": "Publisher",
    ///         "SupportedMessages": []
    ///       }
    ///     ]
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetEndpointInformationResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetEndpointInformationResponse() : base()
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
        /// Dynamic structure that describes the details of this endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Endpoint EndpointInformation
        {
            get;
            set;
        }
    }
}
