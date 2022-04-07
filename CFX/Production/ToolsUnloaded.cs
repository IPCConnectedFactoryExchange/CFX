using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using CFX.Structures;

namespace CFX.Production
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// This message is used when a tool such as stencil or squeegee is unloaded from a cleaning machine
    /// <code language="none">
    /// {
    ///   "TransactionID": "d3e7fe9a-5e42-4121-9edd-a8b46d112ba9",
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
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolsUnloaded : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ToolsUnloaded()
        {

        }
        /// <summary>
        /// Related Transaction ID specified previously by <see cref="CFX.Production.ToolsLoaded"/> Message
        /// </summary>
        public Guid TransactionID
        {
            get;
            set;
        }
        /// <summary>
        /// A list of the tools that were unloaded. It may contain
        /// <see cref="CFX.Structures.SolderPastePrinting.SMTSqueegee"/> or <see cref="CFX.Structures.SolderPastePrinting.SMTStencil"/>
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Tool> Tools
        {
            get;
            set;
        }
    }
}