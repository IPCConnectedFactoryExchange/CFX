using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation
{
    /// <summary>
    /// Cartridge actual temperature
    /// </summary>
    public class MinimumTemperature : SensorInformation
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingStation StationIdentify = new IdentifySolderingStation();
        MinimumTemperature()
        {
            this.Type = SensorType.Temperature;
            this.UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius;
            this.Value = 0;
        }
    }
}