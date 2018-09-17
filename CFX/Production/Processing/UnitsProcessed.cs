using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Production.Processing
{
    /// <summary>
    /// Sent when an endpoint processes one or more production units within
    /// the scope of a work transaction.  Contains dynamic structures that vary
    /// based upon the type of processing that was performed.
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "aed15f89-982f-4a42-82c6-ae468cf32107",
    ///   "CommonProcessData": {
    ///     "$type": "CFX.Structures.SolderReflow.ReflowProcessData, CFX",
    ///     "ConveyorSpeed": 60.0,
    ///     "ZoneData": [
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "PreHeat",
    ///           "StageSequence": 1,
    ///           "StageName": "PreHeat1",
    ///           "StageType": "Work"
    ///         },
    ///         "TopTempSetpoint": 240.0,
    ///         "TopActualTemp": 239.9,
    ///         "TopPower": 240.0,
    ///         "BotTempSetpoint": 235.0,
    ///         "BotActualTemp": 234.8,
    ///         "BotPower": 233.0
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Soak",
    ///           "StageSequence": 2,
    ///           "StageName": "Soak",
    ///           "StageType": "Work"
    ///         },
    ///         "TopTempSetpoint": 240.0,
    ///         "TopActualTemp": 239.9,
    ///         "TopPower": 240.0,
    ///         "BotTempSetpoint": 235.0,
    ///         "BotActualTemp": 234.8,
    ///         "BotPower": 233.0
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Reflow",
    ///           "StageSequence": 3,
    ///           "StageName": "Reflow",
    ///           "StageType": "Work"
    ///         },
    ///         "TopTempSetpoint": 280.0,
    ///         "TopActualTemp": 279.9,
    ///         "TopPower": 300.0,
    ///         "BotTempSetpoint": 275.0,
    ///         "BotActualTemp": 273.8,
    ///         "BotPower": 295.0
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Cool",
    ///           "StageSequence": 4,
    ///           "StageName": "Cool",
    ///           "StageType": "Work"
    ///         },
    ///         "TopTempSetpoint": 50.0,
    ///         "TopActualTemp": 52.9,
    ///         "TopPower": 50.0,
    ///         "BotTempSetpoint": 50.0,
    ///         "BotActualTemp": 51.8,
    ///         "BotPower": 50.0
    ///       }
    ///     ]
    ///   },
    ///   "UnitProcessData": []
    /// }
    /// </code>
    /// <para></para>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class UnitsProcessed : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public UnitsProcessed()
        {
            UnitProcessData = new List<ProcessedUnit>();
        }

        /// <summary>
        /// The id of the work transaction with which this message is associated.
        /// </summary>
        public Guid TransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Dynamic structure containing data that is common to all production units processed
        /// by this work transaction.  Any data that is specfic to an individual production unit
        /// will instead be contained within the UnitProcessData property.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public ProcessData CommonProcessData
        {
            get;
            set;
        }

        /// <summary>
        /// A list of structures containing the processing data for each 
        /// production units processed by this transaction.
        /// </summary>
        public List<ProcessedUnit> UnitProcessData
        {
            get;
            set;
        }

    }
}
