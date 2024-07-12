using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation.Identification;

namespace CFX.Structures.SolderingStation.Sensor
{
    /// <summary>
    /// constant cartridge temperature while the station is in sleep mode
    /// </summary>
    public class SleepTemperature :  SensorInformation
    {
        /// <summary>
        /// Path to cartridge
        /// </summary>
        public IdentifySolderingTool CartridgeIdentify = new IdentifySolderingTool();
        SleepTemperature()
        {
            this.UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius;
            this.Value = 180.0d;
        }
    }
}