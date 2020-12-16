using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using CFX.Structures.SMTPlacement;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent when a new tool is selected for active use at a production endpoint
    /// <para>Example 1 (Generic tool change):</para>
    /// <code language="none">
    /// {
    ///   "OldTool": null,
    ///   "ReturnedToHolder": null,
    ///   "NewTool": {
    ///     "UniqueIdentifier": "UID23890430",
    ///     "Name": "TorqueWrench_123"
    ///   },
    ///   "LoadedFromHolder": {
    ///     "LocationUniqueIdentifier": "UID238943243243",
    ///     "LocationName": "BIN45",
    ///     "BaseName": null
    ///   }
    /// }
    /// </code>
    /// <para>Example 2 (Nozzle change on SMT placement machine):</para>
    /// <code language="none">
    /// {
    ///   "OldTool": null,
    ///   "ReturnedToHolder": null,
    ///   "NewTool": {
    ///     "$type": "CFX.Structures.SMTPlacement.SMTHeadAndNozzle, CFX",
    ///     "HeadId": "HEAD1",
    ///     "HeadNozzleNumber": 1,
    ///     "NozzleType": "TYPE914",
    ///     "UniqueIdentifier": "UID23890430",
    ///     "Name": "NOZZLE234324"
    ///   },
    ///   "LoadedFromHolder": {
    ///     "LocationUniqueIdentifier": "UID238943243243",
    ///     "LocationName": "HOLDER14",
    ///     "BaseName": "NEST2"
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolChanged : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ToolChanged()
        {
        }

        /// <summary>
        /// The tool that was previously in active use (if any) 
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Tool OldTool
        {
            get;
            set;
        }

        /// <summary>
        /// The location on the endpoint where the old tool was returned (if any)
        /// </summary>
        public ToolHolder ReturnedToHolder
        {
            get;
            set;
        }

        /// <summary>
        /// The new active tool
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Tool NewTool
        {
            get;
            set;
        }

        /// <summary>
        /// The location on the endpoint from which the newly active tool was selected 
        /// </summary>
        public ToolHolder LoadedFromHolder
        {
            get;
            set;
        }
    }
}
