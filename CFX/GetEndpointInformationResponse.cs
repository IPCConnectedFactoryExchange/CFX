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
    ///     "CFXHandle": "SMTPlus.Model_11111.SN444555",
    ///     "CFXVersion": "1.0",
    ///     "RequestNetworkUri": "amqp://host55:5688/",
    ///     "RequestTargetAddress": "/queue/SN444555",
    ///     "UniqueIdentifier": "UID1111111111111111",
    ///     "FriendlyName": "SMD Printer 444555",
    ///     "Vendor": "SMT Plus",
    ///     "ModelNumber": "Model_11111",
    ///     "SerialNumber": "SN444555",
    ///     "NumberOfStages": 1,
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
    ///     "$type": "CFX.Structures.SMTPlacement.SMTPlacementEndpoint, CFXnet46",
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
    ///     "Stages": [
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 1,
    ///           "StageName": "BUFFERSTAGE1",
    ///           "StageType": "Buffer"
    ///         },
    ///         "NumberOfFeederStations": 0
    ///       },
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 2,
    ///           "StageName": "WORKSTAGE1",
    ///           "StageType": "Work"
    ///         },
    ///         "NumberOfFeederStations": 100
    ///       },
    ///       {
    ///         "Stage": {
    ///           "StageSequence": 3,
    ///           "StageName": "WORKSTAGE2",
    ///           "StageType": "Work"
    ///         },
    ///         "NumberOfFeederStations": 100
    ///       }
    ///     ],
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
    ///         "HeadId": "HEAD1",
    ///         "PlacementAccuracy": 0.001
    ///       },
    ///       {
    ///         "HeadId": "HEAD2",
    ///         "PlacementAccuracy": 0.001
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
    ///     "NumberOfStages": 4,
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
