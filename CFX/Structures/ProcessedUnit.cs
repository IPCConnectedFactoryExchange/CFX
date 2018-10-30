using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Structure representing a production units that has been processed at
    /// an endpoint involved in the processing of production units.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ProcessedUnit
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProcessedUnit()
        {
            UnitResult = ProcessingResult.Succeeded;
        }

        /// <summary>
        /// Unique ID of Production Unit, Panel, or Carrier
        /// </summary>
        public string UnitIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Logical reference of production unit as defined by CFX position rule (see CFX standard)
        /// </summary>
        public int? UnitPositionNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the overall result of the processing that was performed on the unit.
        /// </summary>
        public ProcessingResult UnitResult
        {
            get;
            set;
        }

        /// <summary>
        /// Process data specific to this particular production unit.  This may be null if there is 
        /// no process data specfific to this individual unit.  For example, if all units processed
        /// during the transaction experienced the same conditions, the UnitsProcessed message will
        /// contain this information, and the UnitProcessData property will be null.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public ProcessData UnitProcessData
        {
            get;
            set;
        }
    }
}
