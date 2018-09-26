using System.Collections.Generic;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint when one or several activities are started, paused, resumed or completed
    /// <code language="none">
    /// CFX.ResourcePerformance.ActivityExecuted:
    /// {
    /// 	“ActivitiesExecuted”: [
    /// 	{
    ///         “$type”: "CFX.ActivityExecutedInformation, CFX",
    /// 		“Activity”: “BoardLoading”,
    ///         “State”: “Started”
    ///     } ],
    ///     “Lane”: “Lane 1”,
    ///     “Stage”: “Stage 1”,
    ///     “Head”: “Head 1”
    /// }
    /// 
    /// CFX.ResourcePerformance.ActivityExecuted:
    /// {
    /// 	“ActivitiesExecuted”: [
    ///     {
    ///         “$type”: "CFX.SMTActivityExecutedInformation, CFX",
    ///         “Activity”: “BoardLoading”,
    ///         “State”: “Completed” 
    ///     },
    ///     {
    ///         “$type”: "CFX.SMTActivityExecutedInformation, CFX",
    ///         “Activity”: “FeederConfiguration”,
    ///         “State”: “Started” 
    ///     } ],
    ///     “Lane”: “Lane 1”,
    ///     “Stage": “Placement Stage 1”,
    ///     “Head": “Head 1”
    /// }
    /// 
    /// CFX.ResourcePerformance.ActivityExecuted:
    /// {
    ///     “ActivitiesExecuted”: [
    ///     {
    ///         “$type”: "CFX.THTActivityExecutedInformation, CFX",
    ///         “Activity”: “ComponentInsertion”,
    ///         “State”: “Started”, 
    ///     } ],
    ///     “Lane”: “Lane 1”,
    ///     “Stage”: “THT Stage 1”,
    ///     “Head”: “Head 1”
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ActivityExecuted : CFXMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActivityExecuted()
        {
            ActivitiesExecuted = new List<ActivityExecutedInformation>();
        }

        /// <summary>
        /// Dynamic list of activities executed information
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<ActivityExecutedInformation> ActivitiesExecuted
        {
            get;
            set;
        }

        /// <summary>
        /// The relevant production lane (if applicable)
        /// </summary>
        public string Lane
        {
            get;
            set;
        }

        /// <summary>
        /// The relevant production stage (if applicable)
        /// </summary>
        public string Stage
        {
            get;
            set;
        }

        /// <summary>
        /// The relevant production head (if applicable)
        /// </summary>
        public string Head
        {
            get;
            set;
        }
    }
}
