using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CFX.Structures.Coating
{
    /// <summary>
    /// A dynamic data structure representing data that was collected during a coating process.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class CoatingProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CoatingProcessData() : base()
        {
            Readings = new List<CoatingMeasurement>();
            Nozzle = new List<CoatingNozzleData>();
        }

        /// <summary>
        /// A list of measurements that were taken in the course of the coating or encapsulation operation.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<CoatingMeasurement> Readings
        {
            get;
            set;
        }

        /// <summary>
        /// Process data (temperatures, etc.) for each Nozzle of the Coating machine at the 
        /// time when this transaction tool place.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<CoatingNozzleData> Nozzle
        {
            get;
            set;
        }
    }
}
