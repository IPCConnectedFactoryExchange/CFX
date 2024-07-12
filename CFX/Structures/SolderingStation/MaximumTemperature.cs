using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Cartridge actual temperature
    /// </summary>
    public class MaximumTemperature : SensorInformation
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingStation StationIdentify = new IdentifySolderingStation();
        MaximumTemperature()
        {
            this.UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius;
            this.Value = 0;
        }
    }
}