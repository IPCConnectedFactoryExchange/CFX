using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Represents a task that was performed during a maintenance operation.
    /// </summary>
    public class MaintenanceTask
    {
        /// <summary>
        /// Free form description of the task.
        /// </summary>
        public string Task
        {
            get;
            set;
        }

        /// <summary>
        /// A string based identifier that uniquely describes this particular instance of the task.
        /// </summary>
        public string TaskId
        {
            get;
            set;
        }

        /// <summary>
        /// The operator who perform the task (optional)
        /// </summary>
        public Operator Operator
        {
            get;
            set;
        }

        /// <summary>
        /// The number of man-hours consumed while performing the task
        /// </summary>
        public double ManHoursConsumed
        {
            get;
            set;
        }
    }
}
