using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures;
using CFX.Structures.Cleaning;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// This message is used when a tool such as stencil or squeegee is loaded into a cleaning machine
    /// <code language="none">
    /// {
    ///   "TransactionID": "72b27f43-78ff-4804-bf5c-45582f6463e3",
    ///   "Tools": [
    ///     {
    ///       "$type": "CFX.Structures.SolderPastePrinting.SMTSqueegee, CFX",
    ///       "CleaningState": "Cleaned",
    ///       "UniqueIdentifier": "SQ1234567890",
    ///       "Name": "Squeegee name"
    ///     },
    ///     {
    ///       "$type": "CFX.Structures.SolderPastePrinting.SMTStencil, CFX",
    ///       "CleaningState": "Cleaned",
    ///       "UniqueIdentifier": "ST1234567890",
    ///       "Name": "Stencil name"
    ///     }
    ///   ],
    ///   "CleaningSteps": [
    ///     {
    ///       "CleaningStepType": "Wash",
    ///       "CleaningStepTime": 200.0,
    ///       "Readings": [
    ///         {
    ///           "ReadingType": "FlowRateAverage",
    ///           "ReadingValue": 12.0
    ///         },
    ///         {
    ///           "ReadingType": "FlowRateMax",
    ///           "ReadingValue": 20.0
    ///         },
    ///         {
    ///           "ReadingType": "FlowRateMin",
    ///           "ReadingValue": 4.0
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolsCleaned : CFXMessage
    {
        /// <summary>
        /// Related Transaction ID specified previously by <see cref="CFX.Production.ToolsLoaded"/> Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the tools that were cleaned. It may contain
        /// <see cref="CFX.Structures.SolderPastePrinting.SMTSqueegee"/> or <see cref="CFX.Structures.SolderPastePrinting.SMTStencil"/>
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Tool> Tools
        {
            get;
            set;
        }

        /// <summary>
        /// A list of cleaning steps
        /// </summary>
        public List<CleaningStep> CleaningSteps
        {
            get;
            set;
        }
    }
}
