using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation.Sensor
{
    /// <summary>
    /// Cartridge actual temperature
    /// </summary>
    public class SolderingPower : SensorInformation
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingTool CartridgeIdentify = new IdentifySolderingTool();
        SolderingPower()
        {
            this.UnitOfMeasure = SensorUnitOfMeasure.W;
            this.Value = 0;
        }
    }
}
