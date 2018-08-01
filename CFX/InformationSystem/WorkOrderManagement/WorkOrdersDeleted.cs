using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// Sent when a Work Order (or sub-batch of a Work Order) has been deleted within an information system (such as ERP or MES).
    /// <code language="none">
    /// {
    ///   "WorkOrderIdentifiers": [
    ///     {
    ///       "WorkOrderNumber": "WO1122334455",
    ///       "Batch": null
    ///     },
    ///     {
    ///       "WorkOrderNumber": "WO9988776666",
    ///       "Batch": "Batch1"
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class WorkOrdersDeleted : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrdersDeleted() : base()
        {
            WorkOrderIdentifiers = new List<WorkOrderIdentifier>();
        }

        /// <summary>
        /// The identifier of the Work Order that has been deleted.
        /// </summary>
        public List<WorkOrderIdentifier> WorkOrderIdentifiers
        {
            get;
            set;
        }
    }
}
