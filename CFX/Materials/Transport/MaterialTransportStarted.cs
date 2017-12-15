using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    public class MaterialTransportStarted : CFXMessage
    {
        public MaterialTransportStarted()
        {
            Materials = new List<MaterialPackage>();
        }

        public string TransportOrderNumber
        {
            get;
            set;
        }

        public Operator StartedBy
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string RelatedWorkOrderNumber
        {
            get;
            set;
        }

        public string FinalDestination
        {
            get;
            set;
        }

        public string NextCheckpoint
        {
            get;
            set;
        }

        public List<MaterialPackage> Materials
        {
            get;
            set;
        }
    }
}
