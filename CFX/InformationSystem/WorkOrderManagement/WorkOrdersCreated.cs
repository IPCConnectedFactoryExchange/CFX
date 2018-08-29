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
    /// <code language="none">
    /// {
    ///   "NewOrders": [
    ///     {
    ///       "WorkOrderIdentifier": {
    ///         "WorkOrderNumber": "WO1122334455",
    ///         "Batch": null
    ///       },
    ///       "Description": "Production Order for PCB Assembly",
    ///       "Status": "AwaitingApproval",
    ///       "Router": "PCB Assembly Process",
    ///       "RouterRevision": "A",
    ///       "LotNumber": "LOT4865",
    ///       "Customer": null,
    ///       "Department": null,
    ///       "CreatedDate": "2018-08-01T13:46:15.5391201-04:00",
    ///       "StartDate": "2018-09-09T00:00:00",
    ///       "DateRequired": "2018-09-15T17:00:00",
    ///       "PartNumber": "1122-3344",
    ///       "PartRevision": "B",
    ///       "Quantity": 220.0,
    ///       "UnitOfMeasure": null,
    ///       "DependsOn": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class WorkOrdersCreated : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrdersCreated() : base()
        {
            NewOrders = new List<WorkOrder>();
        }

        /// <summary>
        /// The new Work Order.
        /// </summary>
        public List<WorkOrder> NewOrders
        {
            get;
            set;
        }
    }
}
