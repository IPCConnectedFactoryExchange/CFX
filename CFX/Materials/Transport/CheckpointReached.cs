using System;
using System.Collections.Generic;
using System.Text;

namespace CFX.Materials.Transport
{
    public class CheckpointReached : CFXMessage
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

        public Operator TrackedBy
        {
            get;
            set;
        }

        public string RelatedWorkOrderNumber
        {
            get;
            set;
        }

        public string Checkpoint
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
    }
}
