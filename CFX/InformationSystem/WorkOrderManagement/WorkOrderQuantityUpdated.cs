using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.InformationSystem.WorkOrderManagement
{
    /// <summary>
    /// Sent when the status of a Work Order (or Work Order sub-batch) has been updated.
    /// <code language="none">
    /// {
    ///   "WorkOrderIdentifier": {
    ///     "WorkOrderId": "WO1122334455",
    ///     "Batch": null
    ///   },
    ///   "NewQuantity": 250.0,
    ///   "PreviousQuantity": 220.0
    /// }
    /// </code>
    /// </summary>
    public class WorkOrderQuantityUpdated : CFXMessage
    {
        /// <summary>
        /// The Identifier of the relevant Work Order or Work Order sub-batch
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// The new quantity of the Work Order (or Work Order sub-batch) 
        /// </summary>
        public double NewQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// The previous quantity of the Work Order (or Work Order sub-batch), if known.
        /// </summary>
        public double? PreviousQuantity
        {
            get;
            set;
        }
    }
}
