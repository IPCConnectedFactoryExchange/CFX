using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation.Sensor
{
    /// <summary>
    /// Cartridge actual temperature
    /// </summary>
    public class SolderingTemperature : SensorInformation
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingTool CartridgeIdentify = new IdentifySolderingTool();
        SolderingTemperature()
        {
            this.UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius;
            this.Value = 0;
        }
    }
}
