using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFX.Structures;

namespace CFX.InformationSystem.ProductionScheduling
{
    /// <summary>
    /// Sent when a Work Order (or Work Order sub-batch) has been scheduled to be executed
    /// at a particular work area at a particular time.
    /// <code language="none">
    /// {
    ///   "ScheduledWorkOrders": [
    ///     {
    ///       "WorkOrderIdentifier": {
    ///         "WorkOrderId": "WO1122334455",
    ///         "Batch": null
    ///       },
    ///       "Scheduler": {
    ///         "OperatorIdentifier": "BADGE4486",
    ///         "ActorType": "Human",
    ///         "LastName": "Doe",
    ///         "FirstName": "John",
    ///         "LoginName": "john.doe@domain1.com"
    ///       },
    ///       "WorkArea": "SMT Line 1",
    ///       "StartTime": "2018-08-02T11:00:00",
    ///       "EndTime": "2018-08-02T15:00:00",
    ///       "ReservedResources": [
    ///         "L1PRINTER1",
    ///         "L1PLACER1",
    ///         "L1PLACER2",
    ///         "L1OVEN1"
    ///       ],
    ///       "ReservedTools": [
    ///         {
    ///           "UniqueIdentifier": "UID23890430",
    ///           "Name": "TorqueWrench_123"
    ///         }
    ///       ],
    ///       "ReservedOperators": [
    ///         {
    ///           "OperatorIdentifier": "BADGE489435",
    ///           "ActorType": "Human",
    ///           "LastName": "Smith",
    ///           "FirstName": "Joseph",
    ///           "LoginName": "joseph.smith@abcdrepairs.com"
    ///         }
    ///       ],
    ///       "ReservedMaterials": [
    ///         {
    ///           "UniqueIdentifier": "UID23849854385",
    ///           "InternalPartNumber": "PN4452",
    ///           "Quantity": 0.0
    ///         },
    ///         {
    ///           "UniqueIdentifier": "UID23849854386",
    ///           "InternalPartNumber": "PN4452",
    ///           "Quantity": 0.0
    ///         },
    ///         {
    ///           "UniqueIdentifier": "UID23849854446",
    ///           "InternalPartNumber": "PN3358",
    ///           "Quantity": 0.0
    ///         }
    ///       ]
    ///     }
    ///   ]
    /// }
    /// </code>
    /// </summary>
    public class WorkOrdersScheduled : CFXMessage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public WorkOrdersScheduled() : base()
        {
            ScheduledWorkOrders = new List<ScheduledWorkOrder>();
        }

        /// <summary>
        /// A list of Work Orders that have been scheduled.
        /// </summary>
        public List<ScheduledWorkOrder> ScheduledWorkOrders
        {
            get;
            set;
        }
    }
}
