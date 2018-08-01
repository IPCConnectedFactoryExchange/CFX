using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// A Work Order (or Work Order sub-batch) has been modified / updated within an information systsem (such as ERP or MES).
    /// <code language="none">
    /// {
    ///   "UpdatedOrders": [
    ///     {
    ///       "WorkOrderIdentifier": {
    ///         "WorkOrderNumber": "WO1122334455",
    ///         "Batch": null
    ///       },
    ///       "Description": "Production Order for PCB Assembly",
    ///       "Status": "AwaitingApproval",
    ///       "Router": "PCB Assembly Process",
    ///       "RouterRevision": "A",
    ///       "LotNumber": "LOT4896",
    ///       "Customer": null,
    ///       "Department": null,
    ///       "CreatedDate": "2018-08-01T13:46:15.8331267-04:00",
    ///       "StartDate": "2018-09-09T00:00:00",
    ///       "DateRequired": "2018-09-15T17:00:00",
    ///       "PartNumber": "1122-5555",
    ///       "PartRevision": "C",
    ///       "Quantity": 220.0,
    ///       "UnitOfMeasure": null,
    ///       "DependsOn": null
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class WorkOrdersUpdated : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrdersUpdated() : base()
        {
            UpdatedOrders = new List<WorkOrder>();
        }

        /// <summary>
        /// The new details of the updated Work Order (or Work Order sub-batch)
        /// </summary>
        public List<WorkOrder> UpdatedOrders
        {
            get;
            set;
        }
    }
}
