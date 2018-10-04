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
    ///       "TimeStamp": "2018-10-04T14:44:18.5895876-04:00",
    ///       "ActivityInstanceId": "40425c0a-6c0d-4c9b-9528-1384aa1e03c1",
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
    ///       "TimeStamp": "2018-10-04T14:44:18.5895876-04:00",
    ///       "ActivityInstanceId": "e0ebc24e-1d06-4802-a6f9-8c3dffe0e1f3",
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
    ///       "TimeStamp": "2018-10-04T14:44:23.5895876-04:00",
    ///       "ActivityInstanceId": "e0ebc24e-1d06-4802-a6f9-8c3dffe0e1f3",
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
    ///       "TimeStamp": "2018-10-04T14:44:43.590587-04:00",
    ///       "ActivityInstanceId": "8dc90190-3bc1-4e8b-8777-53dd2dfd4aef",
    ///       "ActivityState": "Completed",
    ///       "ActivityName": "NOZZLE CHANGE",
    ///       "Comments": null,
    ///       "ValueAddType": "NonValueAdd"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.UnitUnloadActivity, CFX",
    ///       "UnloadTime": "00:00:03.2000000",
    ///       "TimeStamp": "2018-10-04T14:45:13.590587-04:00",
    ///       "ActivityInstanceId": "82518433-ca97-439a-bb7b-c015cc8665dc",
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
