using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;
using Newtonsoft.Json;
 

namespace CFX.Production
{
    /// <summary>
    /// Indicates that one or more activities have been performed in the course of processing one or more production units.
    /// The activities may or may not be value added.  Activities are dynamic structures, and may vary depending upon the 
    /// nature and purpose of the endpoint.
    /// <code language="none">
    /// {
    ///   "TransactionID": "2c24590d-39c5-4039-96a5-91900cecedfa",
    ///   "Stage": {
    ///     "StageSequence": 1,
    ///     "StageName": "STAGE1",
    ///     "StageType": "Work"
    ///   },
    ///   "Activities": [
    ///     {
    ///       "$type": "CFX.Structures.UnitLoadActivity, CFX",
    ///       "LoadTime": "00:00:05.3000000",
    ///       "TimeStamp": "2018-10-04T14:06:03.909334-04:00",
    ///       "ActivityInstanceId": "342e1a12-0be2-44f4-9a21-e22b3148113c",
    ///       "ActivityState": "Completed",
    ///       "ActivityName": "UNIT LOAD",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.UnitAlignmentActivity, CFX",
    ///       "DX": 0.0,
    ///       "DY": 0.0,
    ///       "DZ": 0.0,
    ///       "DXY": 0.0,
    ///       "DZX": 0.0,
    ///       "DZY": 0.0,
    ///       "TimeStamp": "2018-10-04T14:06:03.909334-04:00",
    ///       "ActivityInstanceId": "051a36fd-f9e8-442c-97fe-79bc6a802131",
    ///       "ActivityState": "Started",
    ///       "ActivityName": "UNIT ALIGNMENT",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.UnitAlignmentActivity, CFX",
    ///       "DX": 0.125,
    ///       "DY": 0.104,
    ///       "DZ": 0.0,
    ///       "DXY": 0.987,
    ///       "DZX": 0.0,
    ///       "DZY": 0.0,
    ///       "TimeStamp": "2018-10-04T14:06:08.909334-04:00",
    ///       "ActivityInstanceId": "5bdbabea-067b-4169-ac8e-be27d1dbfb5d",
    ///       "ActivityState": "Completed",
    ///       "ActivityName": "UNIT ALIGNMENT",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.SMTPlacement.SMTNozzleChangeActivity, CFX",
    ///       "OldNozzles": [],
    ///       "NewNozzles": [
    ///         {
    ///           "HeadId": "HEAD1",
    ///           "HeadNozzleNumber": 1,
    ///           "NozzleType": "409A",
    ///           "UniqueIdentifier": "UID234213421",
    ///           "Name": "Nozzle45"
    ///         },
    ///         {
    ///           "HeadId": "HEAD1",
    ///           "HeadNozzleNumber": 2,
    ///           "NozzleType": "302B",
    ///           "UniqueIdentifier": "UID234213421",
    ///           "Name": "Nozzle32"
    ///         }
    ///       ],
    ///       "TimeStamp": "2018-10-04T14:06:28.9103323-04:00",
    ///       "ActivityInstanceId": "9c4396ff-18a7-4f0a-9423-150e340df5c3",
    ///       "ActivityState": "Completed",
    ///       "ActivityName": "NOZZLE CHANGE",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.UnitUnloadActivity, CFX",
    ///       "UnloadTime": "00:00:03.2000000",
    ///       "TimeStamp": "2018-10-04T14:06:58.9103323-04:00",
    ///       "ActivityInstanceId": "2a0df8a4-7e1f-48e6-9522-d59a5662f8ff",
    ///       "ActivityState": "Completed",
    ///       "ActivityName": "UNIT UNLOAD",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ActivitiesExecuted : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ActivitiesExecuted()
        {
            Activities = new List<Activity>();
        }

        /// <summary>
        /// Related Transaction ID previously established by a WorkStarted Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// The related stage name or number
        /// </summary>
        public Stage Stage
        {
            get;
            set;
        }

        /// <summary>
        /// A list of activities that were performed.  The items in this list are dynamic structures, and
        /// may vary depending on the type of endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Activity> Activities
        {
            get;
            set;
        }
    }
}
