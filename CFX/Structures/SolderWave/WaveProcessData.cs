using Newtonsoft.Json;
using System.Collections.Generic;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// Provides information about the conditions within a wave soldering machine.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class WaveProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WaveProcessData()
        {
            WaveZones = new List<WaveZone>();
        }

        /// <summary>
        /// Process data (flux, preheating, etc.) for each zone of the wave soldering machine
        /// </summary>
        public List<WaveZone> WaveZones
        {
            get;
            set;
        }
    }
}