
namespace CFX.Structures.SolderingStation.Identification 
{ 
    /// <summary>
    /// Describes a Soldering Station
    /// <code language="none">
    /// {
    ///     "StationID": "ALE0001",
    ///     "HostId": "EndpointPC_001",
    ///     "Model": "ALE",
    ///     "Reference": "ALE-2A",
    ///     "SoftwareVersion: "8886878"
    /// }
    /// </code>
    /// </summary>
    public class IdentifySolderingStation
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public IdentifySolderingStation()
        {
            StationID = "";
            HostID = "";
            Model = "";
            Reference = "";
            SoftwareVersion = "1.0.0";
        }
        /// <summary>
        /// Soldering Station Unique identifier
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// Unique identifior of PC hosting this soldering station
        /// </summary>
        public string HostID { get; set; }

        /// <summary>
        /// Commercial model descriptor
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Commercial sub-model descriptor
        /// </summary>
        public string Reference { get; set; }
        
        /// <summary>
        /// firmware release unique identifier reported by the soldering station
        /// </summary>
        public string SoftwareVersion { get; set; }
        
    }
}
