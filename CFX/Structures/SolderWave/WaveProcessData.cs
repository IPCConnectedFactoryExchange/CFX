using Newtonsoft.Json;
using System.Collections.Generic;

namespace CFX.Structures.SolderWave
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 2.0 **</para>
    /// Provides information about the conditions within a wave soldering machine.
    /// </summary>
    [CFX.Utilities.CreatedVersion("2.0")]
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class WaveProcessData : ProcessData
    {
        /// <summary>
        /// List of conveyor data (as seen while the processed unit was processed)
        /// </summary>
        public List<Conveyor> Conveyors { get; set; }

        /// <summary>
        /// Measured length [mm] of the unit.
        /// </summary>
        public double UnitLength { get; set; }

        /// <summary>
        /// Setpoint of the length [mm] of the unit.
        /// </summary>
        public double UnitLengthSetpoint { get; set; }

        public N2O2 N2O2 { get; set; }

        /// <summary>
        /// Gets or sets the unit process data.
        /// </summary>
        public WaveUnitProcessData UnitProcessData { get; set; }
    }
}