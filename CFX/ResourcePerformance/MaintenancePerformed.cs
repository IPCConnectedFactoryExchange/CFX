using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.ResourcePerformance
{
    /// <summary>
    /// Sent by a process endpoint to indicate that a maintenance event has taken place. 
    /// Information includes the type of maintenance, maintenance code, parts used, labor etc.
    /// </summary>
    public class MaintenancePerformed : CFXMessage
    {
        public MaintenancePerformed()
        {
            ConsumedMaterials = new List<ConsumedMaterial>();
            Tasks = new List<MaintenanceTask>();
        }

        public MaintenanceType MaintenanceType
        {
            get;
            set;
        }

        public string MaintenanceOrderNumber
        {
            get;
            set;
        }

        public string MaintenanceJobCode
        {
            get;
            set;
        }

        public List<ConsumedMaterial> ConsumedMaterials
        {
            get;
            set;
        }

        public List<MaintenanceTask> Tasks
        {
            get;
            set;
        }
    }
}
