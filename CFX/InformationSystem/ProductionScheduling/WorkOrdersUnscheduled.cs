using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.InformationSystem.ProductionScheduling
{
    /// <summary>
    /// Sent when a previously scheduled Work Order (or Work Order sub-batch) has been unscheduled
    /// at a particular work area at a particular time.
    /// <code language="none">
    /// {
    ///   "ScheduledWorkOrderIdentifiers": [
    ///     {
    ///       "WorkOrderIdentifier": {
    ///         "WorkOrderId": "WO1122334455",
    ///         "Batch": null
    ///       },
    ///       "WorkArea": "SMT Line 1"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class WorkOrdersUnscheduled : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrdersUnscheduled() : base()
        {
            ScheduledWorkOrderIdentifiers = new List<ScheduledWorkOrderIdentifier>();
        }

        /// <summary>
        /// A list of Work Orders that have been scheduled.
        /// </summary>
        public List<ScheduledWorkOrderIdentifier> ScheduledWorkOrderIdentifiers
        {
            get;
            set;
        }
    }
}
