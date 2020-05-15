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
    /// <para>Example 1 (Reflow Oven Processing):</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "a881ac27-9649-41c8-a13e-df118471eb1e",
    ///   "OverallResult": "Succeeded",
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
    /// <para>Example 2 (Conformal Coating Process):</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "d280fd1c-e2cb-4544-be8b-78554c87a0c5",
    ///   "OverallResult": "Succeeded",
    ///   "CommonProcessData": null,
    ///   "UnitProcessData": [
    ///     {
    ///       "UnitIdentifier": "CARRIER55678",
    ///       "UnitPositionNumber": 1,
    ///       "UnitResult": "Succeeded",
    ///       "UnitProcessData": {
    ///         "$type": "CFX.Structures.Coating.CoatingProcessData, CFX",
    ///         "Readings": [
    ///           {
    ///             "MeasurementType": "FluidVolume",
    ///             "ActualValue": 1.1,
    ///             "ExpectedValue": 1.0,
    ///             "MinAcceptableValue": 0.8,
    ///             "MaxAcceptableValue": 1.2,
    ///             "UniqueIdentifier": "c3113de4-c3f9-4c9d-8814-fee2ea12e90b",
    ///             "MeasurementName": "FluidVolume",
    ///             "TimeRecorded": null,
    ///             "Sequence": 0,
    ///             "Result": "Passed",
    ///             "CRDs": null
    ///           },
    ///           {
    ///             "MeasurementType": "FluidPressure",
    ///             "ActualValue": 32.5,
    ///             "ExpectedValue": 32.0,
    ///             "MinAcceptableValue": 31.0,
    ///             "MaxAcceptableValue": 33.8,
    ///             "UniqueIdentifier": "fd246214-573b-40dd-927a-ebfb49d46ae7",
    ///             "MeasurementName": "FluidPressure",
    ///             "TimeRecorded": null,
    ///             "Sequence": 0,
    ///             "Result": "Passed",
    ///             "CRDs": null
    ///           }
    ///         ]
    ///       }
    ///     },
    ///     {
    ///       "UnitIdentifier": "CARRIER55678",
    ///       "UnitPositionNumber": 2,
    ///       "UnitResult": "Succeeded",
    ///       "UnitProcessData": {
    ///         "$type": "CFX.Structures.Coating.CoatingProcessData, CFX",
    ///         "Readings": [
    ///           {
    ///             "MeasurementType": "FluidVolume",
    ///             "ActualValue": 1.1,
    ///             "ExpectedValue": 1.0,
    ///             "MinAcceptableValue": 0.8,
    ///             "MaxAcceptableValue": 1.2,
    ///             "UniqueIdentifier": "11508f6f-fa11-4533-9db0-d3ff99bb03ba",
    ///             "MeasurementName": "FluidVolume",
    ///             "TimeRecorded": null,
    ///             "Sequence": 0,
    ///             "Result": "Passed",
    ///             "CRDs": null
    ///           },
    ///           {
    ///             "MeasurementType": "FluidPressure",
    ///             "ActualValue": 32.5,
    ///             "ExpectedValue": 32.0,
    ///             "MinAcceptableValue": 31.0,
    ///             "MaxAcceptableValue": 33.8,
    ///             "UniqueIdentifier": "a0fff961-4fb4-4851-932d-fb811d2fe83d",
    ///             "MeasurementName": "FluidPressure",
    ///             "TimeRecorded": null,
    ///             "Sequence": 0,
    ///             "Result": "Passed",
    ///             "CRDs": null
    ///           }
    ///         ]
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para></para>
    /// <para>Example 3 (Reflow Profiling Device):</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "40e16df4-acaa-4c4a-9503-fca51ca58876",
    ///   "OverallResult": "Succeeded",
    ///   "CommonProcessData": {
    ///     "$type": "CFX.Structures.ReflowProfiling.ReflowProfilingProcessData, CFX",
    ///     "TimeDateUnitIn": "2018-10-31T09:30:27.05191-04:00",
    ///     "TimeDateUnitOut": "2018-10-31T09:31:49.05191-04:00",
    ///     "ProductName": "Product1",
    ///     "Barcode": "CARRIER55678",
    ///     "RecipeName": "Recipe1",
    ///     "ProcessWindowName": "ProcessWindow001",
    ///     "LotID": "Lot5564",
    ///     "OvenName": "Oven1",
    ///     "Lane": 1,
    ///     "ConveyorSpeedSetpoint": 100.0,
    ///     "MeasuredConveyorSpeed": 102.3,
    ///     "Result": "Passed",
    ///     "ProductionUnitPWI": 89.6,
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
    /// <para>Example 4 (Selective Soldering Process):</para>
    /// <code language="none">
    /// {
    ///   "TransactionId": "a4275a83-4a6a-4656-a92d-402ddd4458d8",
    ///   "OverallResult": "Succeeded",
    ///   "CommonProcessData": {
    ///     "$type": "CFX.Structures.SolderApplication.SelectiveSolderProcessData, CFX",
    ///     "Process_Status": "Completed",
    ///     "RecipeName": "Panasonic 2up",
    ///     "Nitrogen_Pressure": 54.0,
    ///     "Air_Pressure": 62.0,
    ///     "Cycle_Count": 671261,
    ///     "Cycle_Time": "00:01:44.2000000",
    ///     "Nitrogen_Purity": 15.0,
    ///     "Nitrogen_Flow": 39.0,
    ///     "Fiducial_Enabled": true
    ///   },
    ///   "UnitProcessData": [
    ///     {
    ///       "UnitIdentifier": "PANEL4325435",
    ///       "UnitPositionNumber": 1,
    ///       "UnitResult": "Succeeded",
    ///       "UnitProcessData": {
    ///         "$type": "CFX.Structures.SolderApplication.SelectiveSolderPCBProcessData, CFX",
    ///         "ZoneData": [
    ///           {
    ///             "StageSequence": 1,
    ///             "ProcessTime": "00:15:00",
    ///             "Bottle1_Pressure": 7.0,
    ///             "Bottle2_Pressure": 7.0,
    ///             "Flux_Volume": 210.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 0.0,
    ///             "Bot_Preheater_Soak": 0.0,
    ///             "Bot_Preheater_Temp": 0.0,
    ///             "Bot_Preheater_Time": "00:00:00",
    ///             "Bath_Temp": 0.0,
    ///             "Bath_Wave_Enabled": false,
    ///             "Bath_Wave_Hgt": 0.0,
    ///             "Solder_Quantity_Used": 0.0,
    ///             "Fid_XCorrection": 0.15,
    ///             "Fid_YCorrection": 0.2
    ///           },
    ///           {
    ///             "StageSequence": 2,
    ///             "ProcessTime": "00:00:37",
    ///             "Bottle1_Pressure": 0.0,
    ///             "Bottle2_Pressure": 0.0,
    ///             "Flux_Volume": 0.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 50.0,
    ///             "Bot_Preheater_Soak": 10.0,
    ///             "Bot_Preheater_Temp": 108.0,
    ///             "Bot_Preheater_Time": "00:00:37",
    ///             "Bath_Temp": 0.0,
    ///             "Bath_Wave_Enabled": false,
    ///             "Bath_Wave_Hgt": 0.0,
    ///             "Solder_Quantity_Used": 0.0,
    ///             "Fid_XCorrection": 0.0,
    ///             "Fid_YCorrection": 0.0
    ///           },
    ///           {
    ///             "StageSequence": 3,
    ///             "ProcessTime": "00:00:37",
    ///             "Bottle1_Pressure": 0.0,
    ///             "Bottle2_Pressure": 0.0,
    ///             "Flux_Volume": 0.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 50.0,
    ///             "Bot_Preheater_Soak": 10.0,
    ///             "Bot_Preheater_Temp": 108.0,
    ///             "Bot_Preheater_Time": "00:00:37",
    ///             "Bath_Temp": 305.0,
    ///             "Bath_Wave_Enabled": true,
    ///             "Bath_Wave_Hgt": 0.1,
    ///             "Solder_Quantity_Used": 5.0,
    ///             "Fid_XCorrection": 0.15,
    ///             "Fid_YCorrection": 0.2
    ///           }
    ///         ]
    ///       }
    ///     },
    ///     {
    ///       "UnitIdentifier": "PANEL4325435",
    ///       "UnitPositionNumber": 2,
    ///       "UnitResult": "Succeeded",
    ///       "UnitProcessData": {
    ///         "$type": "CFX.Structures.SolderApplication.SelectiveSolderPCBProcessData, CFX",
    ///         "ZoneData": [
    ///           {
    ///             "StageSequence": 1,
    ///             "ProcessTime": "00:15:00",
    ///             "Bottle1_Pressure": 7.0,
    ///             "Bottle2_Pressure": 7.0,
    ///             "Flux_Volume": 210.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 0.0,
    ///             "Bot_Preheater_Soak": 0.0,
    ///             "Bot_Preheater_Temp": 0.0,
    ///             "Bot_Preheater_Time": "00:00:00",
    ///             "Bath_Temp": 0.0,
    ///             "Bath_Wave_Enabled": false,
    ///             "Bath_Wave_Hgt": 0.0,
    ///             "Solder_Quantity_Used": 0.0,
    ///             "Fid_XCorrection": 0.15,
    ///             "Fid_YCorrection": 0.2
    ///           },
    ///           {
    ///             "StageSequence": 2,
    ///             "ProcessTime": "00:00:37",
    ///             "Bottle1_Pressure": 0.0,
    ///             "Bottle2_Pressure": 0.0,
    ///             "Flux_Volume": 0.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 50.0,
    ///             "Bot_Preheater_Soak": 10.0,
    ///             "Bot_Preheater_Temp": 108.0,
    ///             "Bot_Preheater_Time": "00:00:37",
    ///             "Bath_Temp": 0.0,
    ///             "Bath_Wave_Enabled": false,
    ///             "Bath_Wave_Hgt": 0.0,
    ///             "Solder_Quantity_Used": 0.0,
    ///             "Fid_XCorrection": 0.0,
    ///             "Fid_YCorrection": 0.0
    ///           },
    ///           {
    ///             "StageSequence": 3,
    ///             "ProcessTime": "00:00:37",
    ///             "Bottle1_Pressure": 0.0,
    ///             "Bottle2_Pressure": 0.0,
    ///             "Flux_Volume": 0.0,
    ///             "Top_Preheater_Power": 50.0,
    ///             "Top_Preheater_Soak": 10.0,
    ///             "Top_Preheater_Temp": 109.0,
    ///             "Top_Preheater_Time": "00:00:37",
    ///             "Bot_Preheater_Power": 50.0,
    ///             "Bot_Preheater_Soak": 10.0,
    ///             "Bot_Preheater_Temp": 108.0,
    ///             "Bot_Preheater_Time": "00:00:37",
    ///             "Bath_Temp": 305.0,
    ///             "Bath_Wave_Enabled": true,
    ///             "Bath_Wave_Hgt": 0.1,
    ///             "Solder_Quantity_Used": 5.0,
    ///             "Fid_XCorrection": 0.15,
    ///             "Fid_YCorrection": 0.2
    ///           }
    ///         ]
    ///       }
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para>Example 5: Printer Operation Data: for each printed PCB send used Printer process parameters</para>
    /// {
    /// {
    ///   "TransactionId": "b063df28-715d-4ba3-bd39-e9b542e4333c",
    ///   "OverallResult": "Succeeded",
    ///   "CommonProcessData": {
    ///     "$type": "CFX.Structures.SolderPastePrinting.SolderPastePrintingPCBProcessData, CFX",
    ///     "Strokes": [
    ///       {
    ///         "PrintPressure": 1.0,
    ///         "PrintSpeed": 12.0
    ///       },
    ///       {
    ///         "PrintPressure": 2.0,
    ///         "PrintSpeed": 9.0
    ///       }
    ///     ],
    ///     "Separation": {
    ///       "Name": null,
    ///       "SeparationSpeed": 1.6,
    ///       "SeparationDistance": 1.2,
    ///       "SeparationDelay": null
    ///     },
    ///     "PeriodicCleanings": [
    ///       {
    ///         "CleanFrequency": 2,
    ///         "CleanMode": "W"
    ///       }
    ///     ],
    ///     "RecipeName": "RECIPE_123",
    ///     "OffsetX": 1.5,
    ///     "OffsetY": 0.5,
    ///     "OffsetTheta": 2.5,
    ///     "FirstPrintDirection": "FrontToRear",
    ///     "CycleTime": "00:00:00"
    ///   },
    ///   "UnitProcessData": []
    /// }
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
            OverallResult = ProcessingResult.Succeeded;
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
        /// The overall result of the processing operation.
        /// </summary>
        public ProcessingResult OverallResult
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
