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
        /// List of conveyor data (as seen while the processed unit was processed)
        /// </summary>
        public List<Conveyor> Conveyors { get; set; }

        public N2O2 N2O2 { get; set; }

        /// <summary>
        /// Gets or sets the unit process data.
        /// </summary>
        public WaveUnitProcessData UnitProcessData { get; set; }
    }
}