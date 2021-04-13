using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    /// <summary>
    /// A data structure representing an occurrence where a Tool is utilized when processing a specific production unit
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolUsed
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ToolUsed()
        {
            InstalledComponents = new List<InstalledComponent>();
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard section 5.6). 
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// A structure representing the Tool that was utilized
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Tool Tool
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the number of cycles or times that the Tool was used on the production unit
        /// </summary>
        public int UsageCycles
        {
            get;
            set;
        }

        /// <summary>
        /// If components were installed during the operation, this property provides
        /// a detailed listing of the components that were installed.
        /// </summary>
        public List<InstalledComponent> InstalledComponents
        {
            get;
            set;
        }

    }
}
