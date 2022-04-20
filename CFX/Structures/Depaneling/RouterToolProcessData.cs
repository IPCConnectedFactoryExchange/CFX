using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Depaneling
{
    /// <summary>
    /// <para>** NOTE: ADDED in CFX 1.5 **</para>
    /// Provides information about the processing conditions for a depaneling machine at the time when a unit was processed.
    /// </summary>
    [CFX.Utilities.CreatedVersion("1.5")]
    public class RouterToolProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouterToolProcessData()
        {
         
        }

        /// <summary>
        /// Tool Data -Version
        /// </summary>
        public decimal ToolDataVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Machine set point Value- tool bit diameter (in mm)
        /// </summary>
        public decimal ToolDiameter_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Tool bit start used time
        /// </summary>
        public DateTime ToolBitStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Last Tool bit stop used time
        /// </summary>
        public DateTime ToolBitEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Distance of ALL tabs cut since last Bit Change 
        /// </summary>
        public decimal ToolBitDistanceRouted
        {
            get;
            set;
        }

        /// <summary>
        /// Alarm set to optimal distance for bit change
        /// </summary>
        public decimal ToolBitChangeDistanceAlarmSet
        {
            get;
            set;
        }

        /// <summary>
        /// Panel count for batch/period routed
        /// </summary>
        public int NumberOfBoardsRouted
        {
            get;
            set;
        }

        /// <summary>
        /// Machine set point - feed rate routing program (in mm/s)
        /// </summary>
        public decimal FeedRate_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Distance of ALL tabs cut since last bag/filter change in (in Meter).
        /// </summary>
        public decimal VacuumDistanceRouted
        {
            get;
            set;
        }

        /// <summary>
        /// Alarm set to optimal distance for filter change in (Meter).
        /// </summary>
        public decimal VacuumFilterChangeDistanceAlarmSet
        {
            get;
            set;
        }

        /// <summary>
        /// Vacuum or Negative Pressure Level
        /// </summary>
        public decimal ActualVacuumLevel
        {
            get;
            set;
        }
        /// <summary>
        /// Incoming Air Pressure Level
        /// </summary>
        public decimal ActualIncomingPressure
        {
            get;
            set;
        }
        /// <summary>
        /// Electric Power consumption of Machine
        /// </summary>
        public decimal ActualMachinePower
        {
            get;
            set;
        }
        /// <summary>
        /// Max gripper force applied to PCB. (N)(Optional only-Applicable for gripper hardware equipment type)
        /// </summary>
        public decimal ActualGripperForcePickAndPlace
        {
            get;
            set;
        }
        /// <summary>
        /// Machine set point – Spindle Speed (in mm/s)
        /// </summary>
        public decimal SpindleSpeed_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Min Speed at which the Spindle operates - RPM (Revolutions per minute)
        /// </summary>
        public decimal MinSpindleRpm
        {
            get;
            set;
        }

        /// <summary>
        /// Max Speed at which the Spindle operates - RPM (Revolutions per minute)
        /// </summary>
        public decimal MaxSpindleRpm
        {
            get;
            set;
        }
        /// <summary>
        /// List of Axis for Router
        /// </summary>
        public List<Axis> AxisDetails
        {
            get;
            set;
        }


    }
}
