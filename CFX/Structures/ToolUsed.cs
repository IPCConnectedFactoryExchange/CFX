using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CFX.Structures
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ToolUsed
    {
        public ToolUsed()
        {
            InstalledComponents = new List<InstalledComponent>();
        }

        public string UnitIdentifier
        {
            get;
            set;
        }

        public int? UnitPositionNumber
        {
            get;
            set;
        }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public InstallationTool Tool
        {
            get;
            set;
        }

        public int UsageCycles
        {
            get;
            set;
        }

        public List<InstalledComponent> InstalledComponents
        {
            get;
            set;
        }

    }
}
