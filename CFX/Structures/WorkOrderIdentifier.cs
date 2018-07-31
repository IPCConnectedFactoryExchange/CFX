using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Structures
{
    /// <summary>
    /// Uniquely identifies a particular Work Order (or Work Order sub-batch)
    /// </summary>
    public class WorkOrderIdentifier
    {
        /// <summary>
        /// The order number of the Work Order
        /// </summary>
        public string WorkOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// For Work Orders that are divided into two or more sub-batches, this property indicates
        /// the name of the sub-batch.
        /// </summary>
        public string Batch
        {
            get;
            set;
        }
    }
}
