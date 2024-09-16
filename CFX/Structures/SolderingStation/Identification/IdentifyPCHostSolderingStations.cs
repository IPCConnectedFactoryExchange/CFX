using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.SolderingStation.Identification
{
    /// <summary>
    /// Describes a Soldering Station that is used in production
    /// <code language="none">
    /// {
    ///     "CFXHandle": "SolderingPCHost.Model1.001",
    ///     "RequestNetworkUri": "amqp://SolderingStationsHost001/",
    ///     "RequestTargetAddress": "/queue/HandSoldHosts",
    ///     "UniqueIdentifier": "EndpointPC_001",
    ///     "SoftwareVersion: "1.0.0"
    /// }
    /// </code>
    /// </summary>
    public class IdentifyPCHostSolderingStations
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public IdentifyPCHostSolderingStations()
        {
            CFXHandle = "";
            RequestNetworkUri = "";
            RequestTargetAddress = "";
            UniqueIdentifier = "";
            SoftwareVersion = "1.0.0";
        }

        /// <summary>
        /// The handle of the endpoint that is responding
        /// </summary>
        public string CFXHandle { get; set; }
        
        /// <summary>
        /// The network address / Uri to be used for requests to this endpoint
        /// </summary>
        public string RequestNetworkUri { get; set; }
        
        /// <summary>
        /// The AMQP 1.0 target address to be used for requests to this endpoint
        /// </summary>
        public string RequestTargetAddress { get; set; }

        /// <summary>
        /// Endpoint PC Hosting soldering stations unique identifier
        /// </summary>
        public string UniqueIdentifier { get; set; }

        /// <summary>
        /// Middleware software version handling attached soldering stations
        /// </summary>
        public string SoftwareVersion { get; set; }

    }
}
