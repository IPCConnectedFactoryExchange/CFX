using CFX.SolderingStation.Identification;
using System.Collections.Generic;

namespace CFX.Structures.SolderingStation.Identification
{
    /// <summary>
    /// Middleware Stations to AMQP Personal Computer 
    /// <code language="none">
    /// "Identification": 
    /// {
    ///     "CFXHandle": "SolderingPCHost.Model1.001",
    ///     "RequestNetworkUri": "amqp://SolderingStationsHost001/",
    ///     "RequestTargetAddress": "/queue/HandSoldHosts",
    ///     "UniqueIdentifier": "EndpointPC_001",
    ///     "SoftwareVersion: "1.0.0"
    /// },
    /// SolderingStations: 
    /// [
    ///     {
    ///         "StationID": "ALE0001",
    ///         "HostId": "EndpointPC_001",
    ///         "Model": "ALE",
    ///         "Reference": "ALE-2A",
    ///         "SoftwareVersion: "8886878"
    ///     },
    ///     {
    ///         "StationID": "ALE0002",
    ///         "HostId": "EndpointPC_001",
    ///         "Model": "ALE",
    ///         "Reference": "ALE-2A",
    ///         "SoftwareVersion: "8886878"
    ///         }
    /// ]
    /// }
    /// </code>
    /// </summary>
    public class SolderingStationsHostPC
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SolderingStationsHostPC()
        {
            Identification = new IdentifyPCHostSolderingStations();
            SolderingStations = new List<IdentifySolderingStation>();
        }
        /// <summary>
        /// Soldering Stations Host describers
        /// </summary>
        public IdentifyPCHostSolderingStations Identification { get; set; }
        
        /// <summary>
        /// List of hosted Soldering Stations
        /// </summary>
        public List<IdentifySolderingStation> SolderingStations { get; set; }
    }
}
