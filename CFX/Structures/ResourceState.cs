using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// Endpoint state model.  Based on SEMI E10 and E58.
    /// </summary>
    public enum ResourceState
    {
        /// <summary>
        /// Productive Time.  A period of time when the resource is performing its intended function.
        /// </summary>
        PRD = 1000,
        /// <summary>
        /// Pruductive Time.  Regular Work.
        /// </summary>
        PRD_RegularWork = 1100,
        /// <summary>
        /// Pruductive Time.  Work for Third Parties.
        /// </summary>
        PRD_WorkForThirdParties = 1200,
        /// <summary>
        /// Pruductive Time.  Rework.
        /// </summary>
        PRD_Rework = 1300,
        /// <summary>
        /// Pruductive Time.  Engineering.
        /// </summary>
        PRD_Engineering = 1400,

        /// <summary>
        /// Standby.  A period of time, other than non-scheduled time, when the resource is in a condition to perform
        /// its intended function, but it is not operating.
        /// </summary>
        SBY = 2000,
        /// <summary>
        /// Standby.  No Operator.
        /// </summary>
        SBY_NoOperator = 2100,
        /// <summary>
        /// Standby.  No Product (Resource is Starved)
        /// </summary>
        SBY_NoProduct = 2200,
        /// <summary>
        /// Standby.  No Support Tool (A required Tool is missing.  For example, a stencil on a stencil printer.).
        /// </summary>
        SBY_NoSupportTool = 2300,
        /// <summary>
        /// Standby.  Associated Cluster Module Down.
        /// </summary>
        SBY_AssociatedClusterModuleDown = 2400,
        /// <summary>
        /// Standby.  No Host.  (Communication with a critical upper level controller or system has been lost, and 
        /// resource cannot operate).
        /// </summary>
        SBY_NoHost = 2500,

        /// <summary>
        /// Engineering.  A period of time when the resource is in a condition to perform its intended function (no equipment or
        /// process problems exist), but it is operating to conduct engineering experiments.
        /// </summary>
        ENG = 3000,
        /// <summary>
        /// Engineering.  Process experiments.
        /// </summary>
        ENG_ProcessExperiments = 3100,
        /// <summary>
        /// Engineering.  Equipment experiments.
        /// </summary>
        ENG_EquipmentExperiments = 3200,

        /// <summary>
        /// Scheduled Downtime.  A period of time when the resource is not available to perform its intended function due to 
        /// planned downtime events.
        /// </summary>
        SDT = 4000,
        /// <summary>
        /// Scheduled Downtime.  User Maintenance Delay.  Waiting for required maintenance personnel.
        /// </summary>
        SDT_UserMaintenanceDelay = 4100,
        /// <summary>
        /// Scheduled Downtime.  Supply Maintenance Delay.  Waiting for parts required to perform maintenance.
        /// </summary>
        SDT_SuppliedMaintenanceDelay = 4200,
        /// <summary>
        /// Scheduled Downtime.  Actively working on Preventive Maintenance procedures.
        /// </summary>
        SDT_PreventiveMaintenance = 4300,
        /// <summary>
        /// Scheduled Downtime.  Scheduled changed of supply materials.
        /// </summary>
        SDT_ChangeOfConsumables = 4400,
        /// <summary>
        /// Scheduled Downtime.  Scheduled setup time.
        /// </summary>
        SDT_Setup = 4500,
        /// <summary>
        /// Scheduled Downtime.  Scheduled production testing.
        /// </summary>
        SDT_ProductionTest = 4600,
        /// <summary>
        /// Scheduled Downtime.  Facilities related.
        /// </summary>
        SDT_FacilitiesRelated = 4700,

        /// <summary>
        /// Unscheduled Downtime.  A period of time when the resource is not available to perform its intended
        /// function due to unplanned downtime events.
        /// </summary>
        USD = 5000,
        /// <summary>
        /// Unscheduled Downtime.  User Maintenance Delay.  Waiting for required maintenance personnel.
        /// </summary>
        USD_UserMaintentanceDelay = 5100,
        /// <summary>
        /// Unscheduled Downtime.  User Supply Delay.  Waiting for parts required to perform maintenance.
        /// </summary>
        USD_SuppliedMaintenanceDelay = 5200,
        /// <summary>
        /// Unscheduled Downtime.  Repair underway.
        /// </summary>
        USD_Repair = 5300,
        /// <summary>
        /// Unscheduled Downtime.  A condition necessary for proper production is not in order.
        /// </summary>
        USD_OutOfSpecInputMaterial = 5400,
        /// <summary>
        /// Unscheduled Downtime.  Supply material is empty, and needs to be changed.
        /// </summary>
        USD_ChangeOfConsumables = 5500,
        /// <summary>
        /// Unscheduled Downtime.  Facilities related.
        /// </summary>
        USD_FacilitiesRelated = 5600,

        /// <summary>
        /// Non-Scheduled Time.  A period of time when the resource is not scheduled to be utilized in production, such as unworked
        /// shifts, weekends, and holidays (including startup and shutdown).
        /// </summary>
        NST = 6000,
        /// <summary>
        /// Non-Scheduled Time.  Unworked shifts.
        /// </summary>
        NST_UnworkedShifts = 6100,
        /// <summary>
        /// Non-Scheduled Time.  Equipment installation.
        /// </summary>
        NST_EquipmentInstallation = 6200,
        /// <summary>
        /// Non-Scheduled Time.  Equipment modifications.
        /// </summary>
        NST_EquipmentModifications = 6300,
        /// <summary>
        /// Non-Scheduled Time.  Offline training.
        /// </summary>
        NST_OfflineTraining = 6400,
        /// <summary>
        /// Non-Scheduled Time.  Shutdown and Startup.
        /// </summary>
        NST_ShutdownAndStartup = 6500,
    }
}
