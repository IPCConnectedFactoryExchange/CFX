using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.ResourcePerformance
{
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
