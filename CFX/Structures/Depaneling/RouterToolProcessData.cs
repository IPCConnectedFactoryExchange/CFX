using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures.Depaneling
{
    /// <summary>
    /// Provides information about the processing conditions for a depaneling machine at the time when a unit was processed.
    /// </summary>
    public class RouterToolProcessData : ProcessData
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouterToolProcessData()
        {
         
        }

        /// <summary>
        /// Information about the Tool Data -Version
        /// </summary>
        public decimal ToolDataVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the Machine set point Value- tool bit diameter (mm)
        /// </summary>
        public decimal ToolDiameter_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the Tool bit start used time
        /// </summary>
        public DateTime ToolBitStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the Last Tool bit stop used time
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
        /// Information about the Panel count for batch/period
        /// </summary>
        public int NumberOfBoardsRouted
        {
            get;
            set;
        }

        /// <summary>
        /// Information about the Machine set point - feed rate routing program (mm/s)
        /// </summary>
        public decimal FeedRate_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Distance of ALL tabs cut since last bag/filter change in (Meter).
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
        /// Information about the Vacuum or Negative pressure Level
        /// </summary>
        public decimal ActualVacuumLevel
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the Incoming Air pressure Level
        /// </summary>
        public decimal ActualIncomingPressure
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the Electric Power consumption of Machine
        /// </summary>
        public decimal ActualMachinePower
        {
            get;
            set;
        }
        /// <summary>
        /// Information aboout the Max gripper force applied to PCB. (N)(Optional only-Applicable for gripper hardware equipment type)
        /// </summary>
        public decimal ActualGripperForcePickAndPlace
        {
            get;
            set;
        }
        /// <summary>
        /// Information about the Machine set point – Spindle Speed (mm/s)
        /// </summary>
        public decimal SpindleSpeed_SetPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Max Speed at which the Spindle operates - RPM (Revolutions per minute)
        /// </summary>
        public decimal MinSpindleRpm
        {
            get;
            set;
        }

        /// <summary>
        /// Min Speed at which the Spindle operates - RPM (Revolutions per minute)
        /// </summary>
        public decimal MaxSpindleRpm
        {
            get;
            set;
        }
        /// <summary>
        /// List of Axis for Router Tool Parameters Data
        /// </summary>
        public List<Axis> AxisDetails
        {
            get;
            set;
        }


    }
}
