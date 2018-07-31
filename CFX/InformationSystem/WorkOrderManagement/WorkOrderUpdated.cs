using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// A Work Order (or Work Order sub-batch) has been modified / updated within an information systsem (such as ERP or MES).
    /// </summary>
    public class WorkOrderUpdated : CFXMessage
    {
        /// <summary>
        /// The new details of the updated Work Order (or Work Order sub-batch)
        /// </summary>
        public WorkOrder UpdatedOrder
        {
            get;
            set;
        }
    }
}
