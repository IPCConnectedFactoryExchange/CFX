using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CFX.Structures
{
    /// <summary>
    /// Endpoint state model.  Based on SEMI E10 and E58.
    /// </summary>
    [JsonConverter(typeof(StateJsonConverter))]
    public enum ResourceState
    {
        /// <summary>
        /// Productive Time.  A period of time when the resource is performing its intended function.
        /// </summary>
        [EnumMember(Value = "1000")]
        PRD = 1000,
        /// <summary>
        /// Productive Time.  Regular Work.
        /// </summary>
        [EnumMember(Value = "1100")]
        PRD_RegularWork = 1100,
        /// <summary>
        /// Productive Time.  Work for Third Parties.
        /// </summary>
        [EnumMember(Value = "1200")]
        PRD_WorkForThirdParties = 1200,
        /// <summary>
        /// Productive Time.  Rework.
        /// </summary>
        [EnumMember(Value = "1300")]
        PRD_Rework = 1300,
        /// <summary>
        /// Productive Time.  Engineering.
        /// </summary>
        [EnumMember(Value = "1400")]
        PRD_Engineering = 1400,
        /// <summary>
        /// Standby.  A period of time, other than non-scheduled time, when the resource is in a condition to perform
        /// its intended function, but it is not operating.
        /// </summary>
        [EnumMember(Value = "2000")]
        SBY = 2000,
        /// <summary>
        /// Standby.  No Operator.
        /// </summary>
        [EnumMember(Value = "2100")]
        SBY_NoOperator = 2100,
        /// <summary>
        /// Standby.  No Product 
        /// </summary>
        [EnumMember(Value = "2200")]
        SBY_NoProduct = 2200,
        /// <summary>
        /// Standby.  No Product (Resource is Blocked)
        /// </summary>
        [EnumMember(Value = "2201")]
        SBY_NoProductBlocked = 2201,
        /// <summary>
        /// Standby.  No Product (Resource is Starved)
        /// </summary>
        [EnumMember(Value = "2202")]
        SBY_NoProductStarved = 2202,
        /// <summary>
        /// Standby.  No Support Tool (A required Tool is missing.  For example, a stencil on a stencil printer.).
        /// </summary>
        [EnumMember(Value = "2300")]
        SBY_NoSupportTool = 2300,
        /// <summary>
        /// Standby.  Associated Cluster Module Down.
        /// </summary>
        [EnumMember(Value = "2400")]
        SBY_AssociatedClusterModuleDown = 2400,
        /// <summary>
        /// Standby.  No Host.  (Communication with a critical upper level controller or system has been lost, and 
        /// resource cannot operate).
        /// </summary>
        [EnumMember(Value = "2500")]
        SBY_NoHost = 2500,

        /// <summary>
        /// Engineering.  A period of time when the resource is in a condition to perform its intended function (no equipment or
        /// process problems exist), but it is operating to conduct engineering experiments.
        /// </summary>
        [EnumMember(Value = "3000")]
        ENG = 3000,
        /// <summary>
        /// Engineering.  Process experiments.
        /// </summary>
        [EnumMember(Value = "3100")]
        ENG_ProcessExperiments = 3100,
        /// <summary>
        /// Engineering.  Equipment experiments.
        /// </summary>
        [EnumMember(Value = "3200")]
        ENG_EquipmentExperiments = 3200,

        /// <summary>
        /// Scheduled Downtime.  A period of time when the resource is not available to perform its intended function due to 
        /// planned downtime events.
        /// </summary>
        [EnumMember(Value = "4000")]
        SDT = 4000,
        /// <summary>
        /// Scheduled Downtime.  User Maintenance Delay.  Waiting for required maintenance personnel.
        /// </summary>
        [EnumMember(Value = "4100")]
        SDT_UserMaintenanceDelay = 4100,
        /// <summary>
        /// Scheduled Downtime.  Supply Maintenance Delay.  Waiting for parts required to perform maintenance.
        /// </summary>
        [EnumMember(Value = "4200")]
        SDT_SuppliedMaintenanceDelay = 4200,
        /// <summary>
        /// Scheduled Downtime.  Actively working on Preventive Maintenance procedures.
        /// </summary>
        [EnumMember(Value = "4300")]
        SDT_PreventiveMaintenance = 4300,
        /// <summary>
        /// Scheduled Downtime.  Scheduled changed of supply materials.
        /// </summary>
        [EnumMember(Value = "4400")]
        SDT_ChangeOfConsumables = 4400,
        /// <summary>
        /// Scheduled Downtime.  Scheduled setup time.
        /// </summary>
        [EnumMember(Value = "4500")]
        SDT_Setup = 4500,
        /// <summary>
        /// Scheduled Downtime.  Scheduled production testing.
        /// </summary>
        [EnumMember(Value = "4600")]
        SDT_ProductionTest = 4600,
        /// <summary>
        /// Scheduled Downtime.  Facilities related.
        /// </summary>
        [EnumMember(Value = "4700")]
        SDT_FacilitiesRelated = 4700,

        /// <summary>
        /// Unscheduled Downtime.  A period of time when the resource is not available to perform its intended
        /// function due to unplanned downtime events.
        /// </summary>
        [EnumMember(Value = "5000")]
        USD = 5000,
        /// <summary>
        /// Unscheduled Downtime.  User Maintenance Delay.  Waiting for required maintenance personnel.
        /// </summary>
        [EnumMember(Value = "5100")]
        USD_UserMaintentanceDelay = 5100,
        /// <summary>
        /// Unscheduled Downtime.  User Supply Delay.  Waiting for parts required to perform maintenance.
        /// </summary>
        [EnumMember(Value = "5200")]
        USD_SuppliedMaintenanceDelay = 5200,
        /// <summary>
        /// Unscheduled Downtime.  Repair underway.
        /// </summary>
        [EnumMember(Value = "5300")]
        USD_Repair = 5300,
        /// <summary>
        /// Unscheduled Downtime.  A condition necessary for proper production is not in order.
        /// </summary>
        [EnumMember(Value = "5400")]
        USD_OutOfSpecInputMaterial = 5400,
        /// <summary>
        /// Unscheduled Downtime.  Supply material is empty, and needs to be changed.
        /// </summary>
        [EnumMember(Value = "5500")]
        USD_ChangeOfConsumables = 5500,
        /// <summary>
        /// Unscheduled Downtime.  Facilities related.
        /// </summary>
        [EnumMember(Value = "5600")]
        USD_FacilitiesRelated = 5600,

        /// <summary>
        /// Non-Scheduled Time.  A period of time when the resource is not scheduled to be utilized in production, such as unworked
        /// shifts, weekends, and holidays (including startup and shutdown).
        /// </summary>
        [EnumMember(Value = "6000")]
        NST = 6000,
        /// <summary>
        /// Non-Scheduled Time.  Unworked shifts.
        /// </summary>
        [EnumMember(Value = "6100")]
        NST_UnworkedShifts = 6100,
        /// <summary>
        /// Non-Scheduled Time.  Equipment installation.
        /// </summary>
        [EnumMember(Value = "6200")]
        NST_EquipmentInstallation = 6200,
        /// <summary>
        /// Non-Scheduled Time.  Equipment modifications.
        /// </summary>
        [EnumMember(Value = "6300")]
        NST_EquipmentModifications = 6300,
        /// <summary>
        /// Non-Scheduled Time.  Offline training.
        /// </summary>
        [EnumMember(Value = "6400")]
        NST_OfflineTraining = 6400,
        /// <summary>
        /// Non-Scheduled Time.  Shutdown and Startup.
        /// </summary>
        [EnumMember(Value = "6500")]
        NST_ShutdownAndStartup = 6500,
    }

    internal class StateJsonConverter : JsonConverter
    {
        private StringEnumConverter sConv = new StringEnumConverter();

        public StateJsonConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            sConv.WriteJson(writer, value, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                string v = reader.Value.ToString().Trim().ToUpper();
                if (v == "22A0")
                    return ResourceState.SBY_NoProductBlocked;
                else if (v == "22B0")
                    return ResourceState.SBY_NoProductStarved;
            }

            return sConv.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(ResourceState)) return true;
            return false;
        }
    }
}
