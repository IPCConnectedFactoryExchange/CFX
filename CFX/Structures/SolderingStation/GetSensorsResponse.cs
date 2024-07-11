using CFX.Structures;
using CFX.Structures.Maintenance;
using CFX.Structures.SolderingStation;
using CFX.Structures.SolderingStation.Identification;
using CFX.Structures.SolderingStation.Sensor;
using Newtonsoft.Json;

namespace CFX
{

    /// <summary>
    /// Allows any CFX endpoint to request power and temperature of a specified Soldering Station's Tool
    /// <para></para>
    /// Generic example:
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "Result": 
    ///   {
    ///   }
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class GetSensorsResponse : CFXMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GetSensorsResponse() : base()
        {
            SolderingTool = new IdentifySolderingTool();
            
            Temperature = new SensorInformation();
            Temperature.Type = SensorType.Temperature;
            Temperature.UnitOfMeasure = SensorUnitOfMeasure.DegreeCelsius;

            Power = new SensorInformation();
            Power.Type = SensorType.Electric;
            Power.UnitOfMeasure = SensorUnitOfMeasure.NonStandard;
            Power.CustomUnitOfMeasure = "Percent";

            Result = new RequestResult();
        }

        /// <summary>
        /// The result of the request
        /// </summary>
        public RequestResult Result
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure that describes the details of requested object.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public SensorInformation Temperature
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure that describes the details of requested object.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public SensorInformation Power
        {
            get;
            set;
        }

        /// <summary>
        /// Complete path to sensor
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public IdentifySolderingTool SolderingTool
        {
            get;
            set;
        }

    }
}
