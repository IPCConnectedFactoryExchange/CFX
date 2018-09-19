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
    ///   "TransactionId": "c01318f4-f6c8-43cc-b90c-eefd8a7994e7",
    ///   "CommonProcessData": {
    ///     "$type": "CFX.Structures.SolderReflow.ReflowProcessData, CFX",
    ///     "ConveyorSpeed": 60.0,
    ///     "ConveyorSpeedSetpoint": 0.0,
    ///     "ZoneData": [
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "PreHeat",
    ///           "StageSequence": 1,
    ///           "StageName": "Zone1",
    ///           "StageType": "Work"
    ///         },
    ///         "Setpoints": [
    ///           {
    ///             "SubZone": "Top",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 220.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 210.0
    ///           }
    ///         ],
    ///         "Readings": [
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 221.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 220.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 55.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 209.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 195.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 45.0
    ///           }
    ///         ]
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Soak",
    ///           "StageSequence": 2,
    ///           "StageName": "Zone2",
    ///           "StageType": "Work"
    ///         },
    ///         "Setpoints": [
    ///           {
    ///             "SubZone": "Top",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 200.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 190.0
    ///           }
    ///         ],
    ///         "Readings": [
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 201.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 190.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 45.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 189.5
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 185.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 42.0
    ///           }
    ///         ]
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Reflow",
    ///           "StageSequence": 3,
    ///           "StageName": "Zone3",
    ///           "StageType": "Work"
    ///         },
    ///         "Setpoints": [
    ///           {
    ///             "SubZone": "Top",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 250.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 240.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "SetpointType": "O2",
    ///             "Setpoint": 500.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "SetpointType": "Vacuum",
    ///             "Setpoint": 225.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "SetpointType": "VacuumHoldTime",
    ///             "Setpoint": 5.0
    ///           }
    ///         ],
    ///         "Readings": [
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 251.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 230.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 75.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 239.5
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 220.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 65.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "ReadingType": "O2",
    ///             "ReadingValue": 498.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "ReadingType": "Vacuum",
    ///             "ReadingValue": 224.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "ReadingType": "VacuumHoldTime",
    ///             "ReadingValue": 5.0
    ///           },
    ///           {
    ///             "SubZone": "WholeZone",
    ///             "ReadingType": "ConvectionRate",
    ///             "ReadingValue": 250.0
    ///           }
    ///         ]
    ///       },
    ///       {
    ///         "Zone": {
    ///           "ReflowZoneType": "Cool",
    ///           "StageSequence": 4,
    ///           "StageName": "Zone4",
    ///           "StageType": "Work"
    ///         },
    ///         "Setpoints": [
    ///           {
    ///             "SubZone": "Top",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 150.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "SetpointType": "Temperature",
    ///             "Setpoint": 140.0
    ///           }
    ///         ],
    ///         "Readings": [
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 151.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 120.0
    ///           },
    ///           {
    ///             "SubZone": "Top",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 30.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Temperature",
    ///             "ReadingValue": 139.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "Power",
    ///             "ReadingValue": 110.0
    ///           },
    ///           {
    ///             "SubZone": "Bottom",
    ///             "ReadingType": "PowerLevel",
    ///             "ReadingValue": 25.0
    ///           }
    ///         ]
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
