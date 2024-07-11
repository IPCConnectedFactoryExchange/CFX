using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures.SolderingStation.Identification
{
    /// <summary>
    /// Describes a Station cartridge tool port
    /// <code language="none">
    /// {
    ///     "HostID": "EndpointPC_001",
    ///     "StationID": "ALE0001"
    ///     "PortNumber": 1,
    ///     "Reference": "250401"
    /// }
    /// </code>
    /// </summary>
    public class IdentifySolderingTool
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public IdentifySolderingTool()
        {
            HostID = "";
            StationID = "";
            PortNumber = 1;
            Reference = "";
        }
        /// <summary>
        /// Unique Id of PC hosting Station attaching this tool
        /// </summary>
        public string StationID { get; set;  }

        /// <summary>
        /// Unique Id of PC hosting Station attaching this tool
        /// </summary>
        public string HostID { get; set; }
        
        /// <summary>
        /// Multi-cartridge tool port number
        /// </summary>
        public int PortNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Commercial cartridge name
        /// </summary>
        public string CartridgeName
        {
            get;
            set;
        }

        /// <summary>
        /// sub-model , usually is cartridge geometry related
        /// <summary>
        public string Reference
        {
            get;
            set;
        }
        
    }
}
