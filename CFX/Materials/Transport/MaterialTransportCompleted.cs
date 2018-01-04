using System;
using System.Collections.Generic;
using System.Text;
using CFX.Structures;

namespace CFX.Materials.Transport
{
    public class MaterialTransportCompleted : CFXMessage
    {
        public string TransportOrderNumber
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public Operator AcceptedBy
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
    }
}
