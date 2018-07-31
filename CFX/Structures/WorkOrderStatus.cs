using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFX.Structures
{
    /// <summary>
    /// Indicates the current status of a Work Order
    /// </summary>
    public enum WorkOrderStatus
    {
        /// <summary>
        /// The Work Order has not yet been approved, and may not be scheduled or executed.
        /// </summary>
        AwaitingApproval,
        /// <summary>
        /// THe Work Order has been approved, and is available to be scheduled or executed.
        /// </summary>
        ApprovedAndPending,
        /// <summary>
        /// THe Work Order has been scheduled for production, but is not yet executing.
        /// </summary>
        Scheduled,
        /// <summary>
        /// The Work Order is currently being executed, and is in process.
        /// </summary>
        InProcess,
        /// <summary>
        /// The Work Order has been completed.
        /// </summary>
        Completed,
        /// <summary>
        /// The Work Order has been closed.
        /// </summary>
        Closed,
        /// <summary>
        /// The Work Order has been placed on hold.  No work should occur on this order at this time.
        /// </summary>
        OnHold,
        /// <summary>
        /// The Work Order has been cancelled.  
        /// </summary>
        Cancelled
    }
}
