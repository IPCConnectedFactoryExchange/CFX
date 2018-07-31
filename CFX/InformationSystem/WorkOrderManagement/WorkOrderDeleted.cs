using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// Sent when a Work Order (or sub-batch of a Work Order) has been deleted within an information system (such as ERP or MES).
    /// </summary>
    public class WorkOrderDeleted : CFXMessage
    {
        /// <summary>
        /// The identifier of the Work Order that has been deleted.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }
    }
}
