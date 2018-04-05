using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by an endpoint when maintenance has been performed.
    /// Information includes the type of maintenance, maintenance code, parts used, labor etc.
    /// </summary>
    public class MaintenancePerformed : CFXMessage
    {
        public MaintenancePerformed()
        {
            ConsumedMaterials = new List<ConsumedMaterial>();
            Tasks = new List<MaintenanceTask>();
        }

        /// <summary>
        /// An enumeration describing the type of maintenance that was performed
        /// </summary>
        public MaintenanceType MaintenanceType
        {
            get;
            set;
        }

        /// <summary>
        /// The work order number related to this maintenance event
        /// </summary>
        public string MaintenanceOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// An endpoint-specific code indicating the nature of the maintenance
        /// event that was conducted
        /// </summary>
        public string MaintenanceJobCode
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific parts and materials that were consumed while performing
        /// the maintenance event
        /// </summary>
        public List<ConsumedMaterial> ConsumedMaterials
        {
            get;
            set;
        }

        /// <summary>
        /// A list of the specific tasks that were performed while conducting this maintenance
        /// event
        /// </summary>
        public List<MaintenanceTask> Tasks
        {
            get;
            set;
        }
    }
}
