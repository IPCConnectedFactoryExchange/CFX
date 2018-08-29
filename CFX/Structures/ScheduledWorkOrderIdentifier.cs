using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Data structure which identifies a Work Order that has already been scheduled for production.
    /// </summary>
    public class ScheduledWorkOrderIdentifier
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ScheduledWorkOrderIdentifier()
        {
            WorkOrderIdentifier = new WorkOrderIdentifier();
        }

        /// <summary>
        /// Identifies the Work Order (or Work Order sub-batch) that is scheduled.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the physical location where the Work Order will be executed.  A single Work Order
        /// may be scheduled to run in different physical locations at different times.
        /// </summary>
        public string WorkArea
        {
            get;
            set;
        }
    }
}
