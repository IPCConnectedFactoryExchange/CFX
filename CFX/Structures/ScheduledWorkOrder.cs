using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CFX.Structures
{
    /// <summary>
    /// A data structure representing a Work Order that has been scheduled to be executed
    /// at a particular work area within the factory at a particular time.  Includes all of the physical 
    /// resources, tools, personnel, and materials that are required to execute the Work Order.
    /// </summary>
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public class ScheduledWorkOrder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ScheduledWorkOrder()
        {
            WorkOrderIdentifier = new WorkOrderIdentifier();
        }

        /// <summary>
        /// Identifies the Work Order (or Work Order sub-batch) that is scheduled.
        /// </summary>
        public WorkOrderIdentifier WorkOrderIdentifier
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the person who was responsible for scheduling the Work Order (optional).
        /// </summary>
        public Operator Scheduler
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the physical location where the Work Order will be executed.  A single Work Order
        /// may be scheduled to run in different physical locations at different times.
        /// </summary>
        public string WorkArea
        {
            get;
            set;
        }

        /// <summary>
        /// The time when production will begin for this Work Order in the designated work area.
        /// </summary>
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// THe time when production is expected to be completed for this Work Order.
        /// </summary>
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of the physical resources / assets that are required to 
        /// execute the Work Order (Lines, Machines, etc.).
        /// </summary>
        public List<string> ReservedResources
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of the tools that are required to execute the Work Order.
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<Tool> ReservedTools
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of the operators that have been allocated to execute this scheduled
        /// Work Order.
        /// </summary>
        public List<Operator> ReservedOperators
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of the specific materials that are necessary to execute this scheduled Work Order.
        /// </summary>
        public List<MaterialPackage> ReservedMaterials
        {
            get;
            set;
        }
    }
}
