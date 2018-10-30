using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;
using Newtonsoft.Json;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint to indicate that an operator has modified a generic
    /// parameter or configuration setting. This does not apply to settings related to
    /// recipes, which are handled by the RecipeModified event. 
    /// <para></para>
    /// <para>Generic Example</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "ModifiedParameters": [
    ///     {
    ///       "$type": "CFX.Structures.GenericParameter, CFX",
    ///       "Name": "Torque1",
    ///       "Value": "35.6"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// <para></para>
    /// <para>Example fore Solder Reflow Oven</para>
    /// <para></para>
    /// <code language="none">
    /// {
    ///   "ModifiedParameters": [
    ///     {
    ///       "$type": "CFX.Structures.SolderReflow.ReflowOvenParameter, CFX",
    ///       "ConveyorSpeedSetpoint": 50.0,
    ///       "ConveyorWidth": 25.0,
    ///       "ZoneParameters": [
    ///         {
    ///           "Zone": {
    ///             "ReflowZoneType": "PreHeat",
    ///             "StageSequence": 1,
    ///             "StageName": "Zone1",
    ///             "StageType": "Work"
    ///           },
    ///           "Setpoints": [
    ///             {
    ///               "SubZone": "Top",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 220.0
    ///             },
    ///             {
    ///               "SubZone": "Bottom",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 220.0
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "Zone": {
    ///             "ReflowZoneType": "Soak",
    ///             "StageSequence": 2,
    ///             "StageName": "Zone2",
    ///             "StageType": "Work"
    ///           },
    ///           "Setpoints": [
    ///             {
    ///               "SubZone": "Top",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 200.0
    ///             },
    ///             {
    ///               "SubZone": "Bottom",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 220.0
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "Zone": {
    ///             "ReflowZoneType": "Reflow",
    ///             "StageSequence": 3,
    ///             "StageName": "Zone3",
    ///             "StageType": "Work"
    ///           },
    ///           "Setpoints": [
    ///             {
    ///               "SubZone": "Top",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 200.0
    ///             },
    ///             {
    ///               "SubZone": "Bottom",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 220.0
    ///             },
    ///             {
    ///               "SubZone": "WholeZone",
    ///               "SetpointType": "O2",
    ///               "Setpoint": 500.0
    ///             },
    ///             {
    ///               "SubZone": "WholeZone",
    ///               "SetpointType": "Vacuum",
    ///               "Setpoint": 2.0
    ///             },
    ///             {
    ///               "SubZone": "WholeZone",
    ///               "SetpointType": "VacuumHoldTime",
    ///               "Setpoint": 5.0
    ///             }
    ///           ]
    ///         },
    ///         {
    ///           "Zone": {
    ///             "ReflowZoneType": "Cool",
    ///             "StageSequence": 4,
    ///             "StageName": "Zone4",
    ///             "StageType": "Work"
    ///           },
    ///           "Setpoints": [
    ///             {
    ///               "SubZone": "Top",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 105.0
    ///             },
    ///             {
    ///               "SubZone": "Bottom",
    ///               "SetpointType": "Temperature",
    ///               "Setpoint": 105.0
    ///             }
    ///           ]
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class StationParametersModified : CFXMessage
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StationParametersModified()
        {
            ModifiedParameters = new List<Parameter>();

        }

        /// <summary>
        /// A list of the paramters that have been modified, along with their new values.
        /// The Parameter structure is a dynamic structure, and may be of differing types depending on the type of endpoint.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Parameter> ModifiedParameters
        {
            get;
            set;
        }
    }
}
