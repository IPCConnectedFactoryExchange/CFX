using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// Sent when a new production Work Order is created by an information system (such as ERP or MES).
    /// </summary>
    public class WorkOrderCreated : CFXMessage
    {
        /// <summary>
        /// The new Work Order.
        /// </summary>
        public WorkOrder NewOrder
        {
            get;
            set;
        }
    }
}
